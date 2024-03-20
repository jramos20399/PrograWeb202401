

namespace FrontEnd.ApiModels
{
    public class LoginAPI
    {
        public string Username { get; set; }

       
        public string Password { get; set; }

        public TokenModel? Token { get; set; }

        public List<string>? Roles { get; set; }
    }
}

