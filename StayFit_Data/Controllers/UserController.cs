using System.Threading.Channels;
using Azure.Identity;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using StayFit.StayFit_Data.Model.UserDTO;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Linq;


namespace StayFit.StayFit_Data.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
       
        private readonly JwtService _jwtService;

        public UsersController(
            UserManager<IdentityUser> userManager,
          JwtService jwtService
        ) {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        

        [HttpPost]
        public async Task<ActionResult<UserCreateIdentityDto>> NewUser(UserCreateIdentityDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = newUser.Username, Email = newUser.Email },
                newUser.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            newUser.Password = null;
            return Created("", newUser);
        }
        
        
        [HttpPost("BearerToken")]
        public async Task<ActionResult<UserLoginResponceDto>> CreateBearerToken(UserLoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);
            return Ok(token);
        }

        

       
    }
}