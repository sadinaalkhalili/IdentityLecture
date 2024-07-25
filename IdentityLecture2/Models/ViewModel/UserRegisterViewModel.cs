using System.ComponentModel.DataAnnotations;

namespace IdentityLecture2.Models.ViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
