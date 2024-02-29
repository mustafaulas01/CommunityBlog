
using System.Threading.Tasks;
using Business.Abstract;
using Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AccountController:BaseApiController
    {

        private readonly IUserInterface _userInterface;
          private readonly ITokenService _tokenService;
      public AccountController(IUserInterface userInterface,ITokenService tokenService)
      {
        _userInterface=userInterface;
          _tokenService=tokenService;
      }


        [HttpPost("register")]//POST: api/account/register
        public async Task<ActionResult<AppUserDto>> Register([FromBody] AppUserRegisterDto userRegisterDto)
        {
            if (string.IsNullOrEmpty(userRegisterDto.UserName) || string.IsNullOrEmpty(userRegisterDto.Password))
               return BadRequest("Username and Password can not empty");

            var added_user = await _userInterface.RegisterUser(userRegisterDto);

            if(added_user.Id!=0)
            return Ok(added_user);
            else 
            return BadRequest("Username is taken");
    
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginTokenDto>> Login([FromBody] AppUserLoginDto appUserLoginDto)
        {
            bool isUserExist= await _userInterface.UserExists(appUserLoginDto.UserName);
            if(!isUserExist)
            return Unauthorized("Invalid UserName!");

            //check password

            bool isSuccees= await _userInterface.LoginUser(appUserLoginDto);
            if(!isSuccees)
            return Unauthorized("Username or Password is wrong !");
            
        
            var token= _tokenService.CreateToken(appUserLoginDto);
            
            return Ok(new LoginTokenDto(){UserName=appUserLoginDto.UserName.ToLower(),Token=token});

        }
    }


}