using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Identity
{
    public static class AppIdentitySeed
    {
        public static async Task SeedUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    Email = "sharawym275@gmail.com",
                    UserName = "sharawy275",
                };
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}
