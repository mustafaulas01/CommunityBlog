using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
 

    [Authorize]
    public class UsersController:BaseApiController
    {
        
        private readonly IUserInterface _userInterface;
        public UsersController(IUserInterface userInterface)
        {
            _userInterface=userInterface;
        }

       [AllowAnonymous]
       [HttpGet]
       public async Task<IActionResult> GetAllUsers()
       {

               
        return Ok(await _userInterface.GetAllUsersAsync());
       }

       [HttpGet("{id}")]
       public async Task<IActionResult>GetUser(int id)
       {
        
        var user= await _userInterface.GetUserAsync(id);
        if(user==null)
        return NotFound();
        
        return Ok(user);

       }
    }
}