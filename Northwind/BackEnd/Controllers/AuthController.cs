using BackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
                this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user= await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Ok(new Response { Status = "Success", Message = "Credenciales Correctas!" });
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
