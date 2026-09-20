
using System.ComponentModel.DataAnnotations;

namespace Practice_A.Models.Authentication
{
    public class UserRegistrationModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
