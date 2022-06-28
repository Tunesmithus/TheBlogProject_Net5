using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
            UserManager<BlogUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task:Create the Db from the migrations
            //_context.Database.MigrateAsync();

            //Task 1: Seed Roles into the system
            await SeedRolesAsync();


            //Task 2: Seed Users into the system
            await SeedUsersAsync();
            
        }

        private async Task SeedRolesAsync()
        {
            if (_context.Roles.Any())
            {
                return;
            }
            
            
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {

                await _roleManager.CreateAsync(new IdentityRole(role));

            }
                

        }

        private async Task SeedUsersAsync()
        {

            if (_context.Users.Any())
            {
                return;
            }

            BlogUser adminUser = new BlogUser()
            {
                Email = "channing@gmail.com",
                UserName = "channing@gmail.com",
                FirstName = "Channing",
                LastName = "Robertson",
                PhoneNumber = "(601)-310-8018",
                EmailConfirmed = true,
            };

            // Step 2: Use the UserManager to create a new user defined by admin user variable
           await _userManager.CreateAsync(adminUser, "P@ssword!123");

            // Step 3: Add this new user to the administrator role
             await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Moderator
            BlogUser modUser = new BlogUser()
            {
                Email = "Kingston@gmail.com",
                UserName = "Kingston@gmail.com",
                FirstName = "Kingston",
                LastName = "Robertson",
                PhoneNumber = "(469)-233-0452",
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(modUser, "P@ssword!123");


             await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }



    }
}
