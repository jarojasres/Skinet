using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Skinet.Core.Entities.Identity;

namespace Skinet.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public  static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Julián Rojas",
                    Email = "jarojasres@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Julián",
                        LastName = "Rojas",
                        Street = "Calle 49BB",
                        City = "Medellín",
                        State = "Antioquia",
                        Zipcode = "5000035"
                    }
                };

                await userManager.CreateAsync(user, "Alexis89*");
            }
        }
    }

}
