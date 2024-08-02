using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityLecture2.Models.ViewModel
{
    public class UserLoginViewModel
    {
        [Required]
        [Description("Username")]
        public string UserName { get; set; }


        [Required]
        [PasswordPropertyText]
        [Description("Password")]
        public string Password { get; set; }
    }
}