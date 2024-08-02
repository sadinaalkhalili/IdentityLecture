using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityLecture2
{
    public class Identity:IdentityUser
    {
        [StringLength(100)]
        public string firstName { get; set; }
        [StringLength(100)]
        public string lastName { get; set; }
    }
}
