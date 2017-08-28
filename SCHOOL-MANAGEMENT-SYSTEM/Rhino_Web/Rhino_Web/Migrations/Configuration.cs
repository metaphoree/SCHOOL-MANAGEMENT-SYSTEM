namespace Rhino_Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Rhino_Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rhino_Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // protected override void Seed(Rhino_Web.Models.ApplicationDbContext context)
        // {
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
        //}

        protected override void Seed(Rhino_Web.Models.ApplicationDbContext context)
        {
            #region
            bool success = false;

            var _roleManager = new RoleManager<ApplicationRole, string>(new RoleStore<ApplicationRole>(context));
            // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if(!_roleManager.RoleExists("Admin"))
            success = this.CreateRole(_roleManager, "Admin", "Global Access");
            //if (!success == true) return success;
            if (!_roleManager.RoleExists("CanEdit"))
                success = this.CreateRole(_roleManager, "CanEdit", "Edit existing records");
            //if (!success == true) return success;
            if (!_roleManager.RoleExists("User"))
                success = this.CreateRole(_roleManager, "User", "Restricted to business domain activity");
            //if (!success) return success;

            // Create my debug (testing) objects here

            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new ApplicationUser();
            PasswordHasher passwordHasher = new PasswordHasher();

            user.UserName = "myemail@myemail.com";
            user.Email = "myemail@myemail.com";
            user.PhoneNumber = "01759903632";
            user.Name = "Nabil Sarwar";
            user.Parmanent_District = "Narayanganj";
            user.Parmanent_Thana = "Fatullah";
            user.Parmanent_House_No = "19/3";
            user.Present_District = "Dhaka";
            user.Present_Thana = "Dhaka";
            user.Present_House_No = "Dhaka";
            user.DateOfBirth = DateTime.Now;
            user.Gender = "Dhaka";
            user.School_Name = "Dhaka";
            user.EmailConfirmed = true;
            user.PasswordHash = passwordHasher.HashPassword("myemail@123A");
            user.PhoneNumberConfirmed = false;
            user.LockoutEnabled = false;

    
            if (!UsersExists(userManager, "myemail@myemail.com"))
            {
                var result = userManager.Create(user);
            }
            if (!(UsersExists(userManager, "myemail@myemail.com") && UserHasRole(userManager,user.Id,"Admin", "myemail@myemail.com"))) {
                success = this.AddUserToRole(userManager, user.Id, "Admin");
                // if (!success) return success;

                success = this.AddUserToRole(userManager, user.Id, "CanEdit");
                // if (!success) return success;

                success = this.AddUserToRole(userManager, user.Id, "User");
                //  if (!success) return success;
            }
            //return success;
            #endregion
        }

        public bool RoleExists(RoleManager<ApplicationRole, string> roleManager, string name)
        {

            return roleManager.RoleExists(name);
        }

        public bool CreateRole(RoleManager<ApplicationRole, string> _roleManager, string name, string description = "")
        {
            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
            return idResult.Succeeded;
        }

        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        {
            //var idResult = _userManager.AddToRole()
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        public bool UserHasRole(ApplicationUserManager userManager,string userId,string roleName,string email) {
            bool userRoles = userManager.IsInRole(GettingUserIdByEmail(userManager, email), roleName);
            return userRoles;

        }
        public bool UsersExists(ApplicationUserManager _userManager,string email) {

            var user = _userManager.FindByEmail(email);
            return user != null?true:false;

        }
        public string GettingUserIdByEmail(ApplicationUserManager userManager,string email) {
            var user = userManager.FindByEmail(email);
            if (user != null) { return user.Id; }
            else { return "FakeId"; }


        }


        





        /*
         public void ClearUserRoles(ApplicationUserManager userManager, string userId)
         {
             var user = userManager.FindById(userId);

             var currentRoles = new List<IdentityUserRole>();

             //currentRoles.AddRange()
             currentRoles.AddRange(user.UserRoles);
             foreach (IdentityUserRole role in currentRoles)
             {
                //role.
                 userManager.RemoveFromRole(userId, role.Role.Name);
                 //userManager.RemoveFromRole()

             }
         }
        */
        public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        {
            userManager.RemoveFromRole(userId, roleName);
        }
        /*
                public void DeleteRole(ApplicationDbContext context, ApplicationUserManager userManager, string roleId)
                {
                    var roleUsers = userManager.Users.Select(u => u.UserRoles.Any(r => r.RoleId == roleId));
                   // var roleuser=userManager.Users
                    var role = context.Roles.Find(roleId);
                  //  var role=context.

                    foreach (var user in roleUsers)
                    {
                        this.RemoveFromRole(userManager, user.Id, role.Name);
                    }
                    context.Roles.Remove(role);
                    context.SaveChanges();
                }
                */
        /// <summary>
        /// Context Initializer
        /// </summary>
        /*
        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

    */
















    }
}
