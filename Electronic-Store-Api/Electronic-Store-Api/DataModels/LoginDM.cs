using System.ComponentModel.DataAnnotations;

namespace Electronic_Store_Api.DataModels
{
    public class LoginDM
    {
        [Required]
        public string esUserName { get; set; }
        [Required]
        public string esPassword { get; set; }
    }
}
