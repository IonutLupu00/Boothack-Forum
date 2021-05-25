using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public class DataSeeder
    {
        private ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public  Task SeedSuperUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);

            

            var user = new ApplicationUser
            {
                UserName = "Admin",
                NormalizedUserName = "admin",
                Email = "ionutlupu5000@gmail.com",
                NormalizedEmail = "ionutlupu5000@gmail.com",
                EmailConfirmed = false,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = hasher.HashPassword(user, "?RyR5$k4ift?6Lv");
            user.PasswordHash = hashedPassword;

            var isAdminRole = _context.Roles.Any(role => role.Name == "Admin");

            if (!isAdminRole)
            {
               roleStore.CreateAsync(new IdentityRole {Name="Admin", NormalizedName = "admin" });
            }

            var hasSuperUser = _context.Users.Any(u => u.NormalizedUserName == user.NormalizedUserName);

            if (!hasSuperUser)
            {
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, "Admin");
            }
            return Task.CompletedTask;
        }
        
    }
}
