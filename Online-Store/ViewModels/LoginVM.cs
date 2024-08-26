using System.ComponentModel.DataAnnotations;

namespace Online_Store.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
