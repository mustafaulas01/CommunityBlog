using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
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
    }
}