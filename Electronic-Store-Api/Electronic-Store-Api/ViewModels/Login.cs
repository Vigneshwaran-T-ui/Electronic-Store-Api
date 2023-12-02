using System.ComponentModel.DataAnnotations;

namespace Electronic_Store_Api.ViewModels
{
    public class Login
    {
        public string esUserName { get; set; }
        public string esPassword { get; set; }
    }
}
