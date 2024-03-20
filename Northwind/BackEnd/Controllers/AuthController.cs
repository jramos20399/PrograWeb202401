using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;
        ITokenService TokenService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
                this.userManager = userManager;
            this.TokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user= await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                TokenModel tokenModel = TokenService.CreateToken(user, userRoles.ToList());
                LoginModel usuario = new LoginModel
                {
                    Username = model.Username,
                    Roles = userRoles.ToList(),
                    Password= "",
                    Token = tokenModel
                };

                return Ok(usuario);
            }

            return Unauthorized(new Response { Status = "Error", Message = "Credenciales Incorrectas" });
        }
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar([FromBody]RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.Username);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };



            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


    }
}
