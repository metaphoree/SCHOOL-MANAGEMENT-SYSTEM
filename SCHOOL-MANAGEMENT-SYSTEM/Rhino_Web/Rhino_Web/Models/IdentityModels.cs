using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rhino_Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        #region(IdentityUserData)
        public string Name { get; set; }
        public string Parmanent_District { get; set; }
        public string Parmanent_Thana { get; set; }
        public string Parmanent_House_No { get; set; }
        public string Present_District { get; set; }
        public string Present_Thana { get; set; }
        public string Present_House_No { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Gender { get; set; }
        public string School_Name { get; set; }
        public virtual ICollection<IdentityUserRole> UserRoles { get; set; }
        public virtual ICollection<StudentData> StudentDatas { get; set; }
       
        #endregion
        #region(GenerateUserIdentityAsync Method)

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
#endregion
    }
    #region(StudentDataClass)
    public partial class StudentData
    {
        [Key]
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Roll{get;set;}
        public string Gender { get; set; }
        public string _Class { get; set; }
        public string Section { get; set; }
        public string Fathers_Name { get; set; }
        public string Mothers_Name { get; set; }
        public string Parmanent_District { get; set; }
        public string Parmanent_Thana { get; set; }
        public string Parmanent_House_No { get; set; }
        public string Present_District { get; set; }
        public string Present_Thana { get; set; }
        public string Present_House_No { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Blood_Group { get; set; }
        public string Parents_Mobile { get; set; }
        public string Picture { get; set; }
        public string Birth_Registration_Number { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
#endregion
    // public System.Data.Entity.DbSet<StudentData> StudentDatas { get; set; }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

     
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<IdentityDb, Configuration>());
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public System.Data.Entity.DbSet<StudentData> StudentDatas { get; set; }
        #region(OnModelCreating)
        /*
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           if (modelBuilder == null)
           {
               throw new ArgumentNullException("ModelBuilder is NULL");
           }

           base.OnModelCreating(modelBuilder);

           //Defining the keys and relations
           modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
           modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
          modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.UserRoles);
           modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
       }


          */
        #endregion

        #region(PreviousSeedCode)

        //        public bool Seed(ApplicationDbContext context) {
        //#region
        //            bool success = false;

        //            var _roleManager = new RoleManager<ApplicationRole,string>(new RoleStore<ApplicationRole>(context));
        //            // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


        //            success = this.CreateRole(_roleManager, "Admin", "Global Access");
        //            if (!success == true) return success;

        //            success = this.CreateRole(_roleManager, "CanEdit", "Edit existing records");
        //            if (!success == true) return success;

        //            success = this.CreateRole(_roleManager, "User", "Restricted to business domain activity");
        //            if (!success) return success;

        //            // Create my debug (testing) objects here

        //            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

        //            ApplicationUser user = new ApplicationUser();
        //            PasswordHasher passwordHasher = new PasswordHasher();

        //            user.UserName = "myemail@myemail.com";
        //            user.Email = "myemail@myemail.com";
        //            user.PhoneNumber = "01759903632";
        //            user.Name = "Nabil Sarwar";
        //            user.Parmanent_District = "Narayanganj";
        //            user.Parmanent_Thana = "Fatullah";
        //            user.Parmanent_House_No = "19/3";
        //            user.Present_District = "Dhaka";
        //                    user.Present_Thana = "Dhaka";
        //            user.Present_House_No = "Dhaka";
        //            user.DateOfBirth = DateTime.Now;
        //            user.Gender = "Dhaka";
        //            user.School_Name = "Dhaka";
        //            user.EmailConfirmed = true;


        //            //IdentityResult result = userManager.Create(user, "myemail");
        //            var result =  userManager.Create(user, "myemail");
        //            success = this.AddUserToRole(userManager, user.Id, "Admin");
        //            if (!success) return success;

        //            success = this.AddUserToRole(userManager, user.Id, "CanEdit");
        //            if (!success) return success;

        //            success = this.AddUserToRole(userManager, user.Id, "User");
        //            if (!success) return success;

        //            return success;
        //#endregion
        //             }

        //        public bool RoleExists(RoleManager<ApplicationRole,string> roleManager,string name)
        //        {

        //            return roleManager.RoleExists(name);
        //        }

        //        public bool CreateRole(RoleManager<ApplicationRole,string> _roleManager, string name, string description = "")
        //        {
        //            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
        //            return idResult.Succeeded;
        //        }

        //        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        //        {
        //            //var idResult = _userManager.AddToRole()
        //            var idResult = _userManager.AddToRole(userId, roleName);
        //            return idResult.Succeeded;
        //        }
        //       /*
        //        public void ClearUserRoles(ApplicationUserManager userManager, string userId)
        //        {
        //            var user = userManager.FindById(userId);

        //            var currentRoles = new List<IdentityUserRole>();

        //            //currentRoles.AddRange()
        //            currentRoles.AddRange(user.UserRoles);
        //            foreach (IdentityUserRole role in currentRoles)
        //            {
        //               //role.
        //                userManager.RemoveFromRole(userId, role.Role.Name);
        //                //userManager.RemoveFromRole()

        //            }
        //        }
        //       */
        //        public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        //        {
        //            userManager.RemoveFromRole(userId, roleName);
        //        }
        //        /*
        //                public void DeleteRole(ApplicationDbContext context, ApplicationUserManager userManager, string roleId)
        //                {
        //                    var roleUsers = userManager.Users.Select(u => u.UserRoles.Any(r => r.RoleId == roleId));
        //                   // var roleuser=userManager.Users
        //                    var role = context.Roles.Find(roleId);
        //                  //  var role=context.

        //                    foreach (var user in roleUsers)
        //                    {
        //                        this.RemoveFromRole(userManager, user.Id, role.Name);
        //                    }
        //                    context.Roles.Remove(role);
        //                    context.SaveChanges();
        //                }
        //                */
        //        /// <summary>
        //        /// Context Initializer
        //        /// </summary>
        //        /*
        //        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        //        {
        //            protected override void Seed(ApplicationDbContext context)
        //            {
        //                context.Seed(context);

        //                base.Seed(context);
        //            }
        //        }

        //    */


        #endregion

    }
}