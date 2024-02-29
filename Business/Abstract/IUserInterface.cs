using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Entities;

namespace Business.Abstract
{
    public interface IUserInterface
    {
        Task<List<AppUser>> GetAllUsersAsync();

        Task<AppUser>GetUserAsync(int id);
        Task<AppUser>GetUserByNameAsync(string userName);

        Task<AppUserDto>RegisterUser(AppUserRegisterDto userRegisterDto);

        Task<bool> UserExists(string userName);

        Task<bool>LoginUser(AppUserLoginDto userLoginDto);
       

    }
}