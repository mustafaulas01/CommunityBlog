using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Business.Abstract
{
    public interface IUserInterface
    {
        Task<List<AppUser>> GetAllUsersAsync();

        Task<AppUser>GetUserAsync(int id);

    }
}