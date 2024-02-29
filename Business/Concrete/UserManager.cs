using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserManager : IUserInterface
    {
        private readonly AstralContext _context;

      

        public UserManager(AstralContext context)
        {
            _context=context;
          
        }
        public async Task<List<AppUser>> GetAllUsersAsync()
        {
           

           return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
           return await _context.AppUsers.FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<AppUser> GetUserByNameAsync(string userName)
        {
           return await _context.AppUsers.FirstOrDefaultAsync(a=>a.UserName.ToLower()==userName.ToLower());
        }

        public async Task<bool> LoginUser(AppUserLoginDto userLoginDto)
        {
          
             var user=await _context.AppUsers.SingleOrDefaultAsync(a=>a.UserName==userLoginDto.UserName);

             using var hmac=new HMACSHA512(user.PasswordSalt);

             var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for(int i=0;i<computedHash.Length;i++)
            {
                if(computedHash[i]!=user.PasswordHash[i])
                return false;

            }


            return true;
        }

        public async Task<AppUserDto> RegisterUser(AppUserRegisterDto userRegisterDto)
        {

              bool isUserExist=await UserExists(userRegisterDto.UserName);

        
              if(!isUserExist)
              {

                using var hmac = new HMACSHA512();

                var user = new AppUser
                {
                    UserName = userRegisterDto.UserName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                    PasswordSalt = hmac.Key
                };

                _context.AppUsers.Add(user);
                await _context.SaveChangesAsync();
               return new AppUserDto() {Id=user.Id,UserName=user.UserName};
            } 
            else
            {
             return new AppUserDto() {Id=0,UserName="Empty"};
            }


    
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.AppUsers.AnyAsync(a=>a.UserName.ToLower()==userName.ToLower());
        }
    }
}