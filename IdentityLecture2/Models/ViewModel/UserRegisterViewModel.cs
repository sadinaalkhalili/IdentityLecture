using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityLecture2.Models.ViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        [Description("Username")]
        public string UserName { get; set; }
   
        [Required]
        [EmailAddress]
        [Description("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        [Description("firstName")]
        public string firstName { get; set; }
        [Required]
        [StringLength(100)]
        [Description("lastName")]
        public string lastName { get; set; }

        [Required]
        [PasswordPropertyText]
        [Description("Password")]
        public string Password { get; set; }
        [Required]
        [PasswordPropertyText]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
