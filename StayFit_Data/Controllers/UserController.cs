using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;
        

        public UsersController(
            UserManager<User> userManager,
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
                new User() { UserName = newUser.Username, Email = newUser.Email },
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
        
        

        [HttpPost("SaveUserByStripeCustomerKey")]
        public async Task<ActionResult> SaveUserByStripeCustomerKey( [FromBody] UserPaymentAddResponce customerStripe )
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Replace 'YOUR_SECRET_KEY' with the secret key used to sign the token
            var secretKey = "this is the secret key for the jwt, it must be kept secure";

            try
            {
                // Read and validate the JWT token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                // Extract the claims from the JWT token
                var claimsPrincipal = tokenHandler.ValidateToken(customerStripe.jwtToken, tokenValidationParameters, out var validatedToken);

                // Find the user ID claim
                var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);

                if (userIdClaim != null)
                {
                    var userName = userIdClaim.Value;
                    var user = await _userManager.FindByNameAsync(userName);
                    user.StripeAccountId = customerStripe.customerId;
                    await _userManager.UpdateAsync(user);
                    return Ok(user.StripeAccountId);
                }
                else
                {
                    throw new Exception("User ID claim not found in JWT token.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to decode JWT token: " + ex.Message);
                return null;
            }
        }
        
        
        
        [Authorize]
        [HttpPost("CheckPayment")]
        public async Task<ActionResult> CheckPayment( [FromBody] UserPaymentCheckRequest jwt )
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Replace 'YOUR_SECRET_KEY' with the secret key used to sign the token
            var secretKey = "this is the secret key for the jwt, it must be kept secure";

            try
            {
                // Read and validate the JWT token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                // Extract the claims from the JWT token
                var claimsPrincipal = tokenHandler.ValidateToken(jwt.jwtToken, tokenValidationParameters, out var validatedToken);

                // Find the user ID claim
                var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);

                if (userIdClaim != null)
                {
                    var userName = userIdClaim.Value;
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user.StripeAccountId != null)
                    {
                        UserPaymentCheckResponse response = new UserPaymentCheckResponse();
                        response.stripeId = user.StripeAccountId;
                        response.clientEmail = user.Email;
                        return Ok(response);
                    }
                    else
                    {
                       return BadRequest();
                    }
                    
                }
                else
                {
                    throw new Exception("User ID claim not found in JWT token.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to decode JWT token: " + ex.Message);
                return null;
            }
        }
        
    }
}