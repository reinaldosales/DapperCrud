using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
