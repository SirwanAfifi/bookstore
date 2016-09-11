using System.Collections.Generic;
using Microsoft.Owin.Security;

namespace Owin.Demo.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<AuthenticationDescription> GetAuthenticationTypes { get; set; }
    }
}