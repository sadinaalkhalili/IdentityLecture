using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityLecture2.Data
{
    public class Configurations
    {
        #region Seeding
        internal void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
        }
        internal void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(

                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }


            );

        }
        #endregion


    }
}
