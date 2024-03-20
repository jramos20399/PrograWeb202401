using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository _ServiceRepository;

        public SecurityHelper(IServiceRepository serviceRepository)
        {
                _ServiceRepository = serviceRepository;
        }

        LoginViewModel Convertir(LoginAPI loginAPI)
        {
            return new LoginViewModel
            {
                UserName = loginAPI.Username,
                roles = loginAPI.Roles,
                tokenString = loginAPI.Token.Token

            };
        }

        public LoginViewModel Login(LoginViewModel user)
        {
            try
            {
                

               
                HttpResponseMessage responseMessage = _ServiceRepository
                    .PostResponse("api/Auth/login", new { user.UserName, user.Password });
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                LoginAPI loginAPI = JsonConvert.DeserializeObject<LoginAPI>(content);

                
                return Convertir(loginAPI);



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
