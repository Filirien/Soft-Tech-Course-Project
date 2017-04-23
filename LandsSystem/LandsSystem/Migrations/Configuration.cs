namespace LandsSystem.Migrations
{
    using LandsSystem.Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LandsSystem.Data.LandsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LandsSystem.Data.LandsDbContext context)
        {
            // Seed Users
            if (!context.Users.Any())
            {
                CreateUser(context, "niki@gmail.com", "123", "Nikolay", "Georgiev", 55);
                CreateUser(context, "denis@gmail.com", "123", "Denis", "Vasilev", 65);
                CreateUser(context, "marin@gmail.com", "123", "Marin", "Kunovski", 75);
                CreateUser(context, "pesho.pesho@gmail.com", "123", "Pesho", "Pesho", 8);
            }

            // Seed Roles
            if (!context.Roles.Any())
            {
                CreateRole(context, "Administrator");

                // Seed Roles To Users
                AddUserToRole(context, "niki@gmail.com", "Administrator");
                AddUserToRole(context, "denis@gmail.com", "Administrator");
                AddUserToRole(context, "marin@gmail.com", "Administrator");
            }
            //

            //
        }
        private void CreateUser(LandsDbContext context, string email, string password, string firstName, string lastName, int age)
        {
            var userManager = new UserManager<User>(
                new UserStore<User>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var rnd = new Random();

            var user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                RegisteredOn = DateTime.Now.AddDays(rnd.Next(0, 300))
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(LandsDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(LandsDbContext context, string userName, string roleName)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return;
            }

            var userManager = new UserManager<User>(
                new UserStore<User>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
