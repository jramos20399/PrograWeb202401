using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        ISecurityHelper SecurityHelper;

        public AccountController(ISecurityHelper securityHelper)
        {
                this.SecurityHelper = securityHelper;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Login(string ReturneUrl="/")
        {
            LoginViewModel user = new LoginViewModel();
            user.ReturnUrl = ReturneUrl;
            return View(user);  

        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var url = user.ReturnUrl;
                    user = SecurityHelper.Login(user);
                    user.ReturnUrl = url;
                   
                    HttpContext.Session.SetString("token", user.tokenString);

        
                   
                    var claims = new List<Claim>() {
                                     new Claim(ClaimTypes.NameIdentifier, user.UserName as string),
                                         new Claim(ClaimTypes.Name, user.UserName as string)
                    };

                    foreach (var item in user.roles)
                    {
                        claims.Add(
                              new Claim(ClaimTypes.Role, item as string)

                            );
                    }




                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = user.RememberLogin
                    });
                    //return View("AccessDenied");
                    return LocalRedirect(user.ReturnUrl);
                }

                return View(user);



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
