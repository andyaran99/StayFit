﻿using StayFit.StayFit_Data.Model.UserDTO;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace StayFit.StayFit_Data.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public UsersController(
            UserManager<IdentityUser> userManager,
         UserService userService, JwtService jwtService
        ) {
            _userManager = userManager;
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewDto>>> ListUsers()
        {
            return await _userService.ListUsers();
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateIdentityDto>> NewUser(UserCreateIdentityDto newUser)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = newUser.UserName, Email = newUser.Email },
                newUser.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            newUser.Password = null;
            return Created("", newUser);
        }
        

        /*[HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserViewDto>> GetUser(int userId)
        {
            try
            {
                return await _userService.GetById(userId);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"User with ID:{userId} not found.");
            }
        }*/
        
        [HttpGet("{username}")]
        public async Task<ActionResult<UserCreateIdentityDto>> GetUserByName(string username)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return new UserCreateIdentityDto()
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }
        
        [HttpPost("BearerToken")]
        public async Task<ActionResult<UserLoginResponceDto>> CreateBearerToken(UserLoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByNameAsync(request.Username);
            Console.WriteLine(user.ToString());

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
        

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            { 
                await _userService.DeleteById(userId);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound($"User with ID:{userId} not found.");
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserViewDto>> UpdateUser(UserUpdateDto updatedUser)
        {
            try
            {
                return await _userService.UpdateUser(updatedUser);
            }
            catch (DbUpdateException)
            {
                return NotFound($"User with ID:{updatedUser.Id} not found.");
            }
        }
    }
}