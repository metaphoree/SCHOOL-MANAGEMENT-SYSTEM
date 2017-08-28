using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Rhino_Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rhino_Web.Models
{
    public class Isit
    {
        public static string Admin1 = "false";
        public static string UserEmailIs1 = "NotAssigned";
      public static  ApplicationDbContext context = new ApplicationDbContext();






        public static string Admin
        {
            get { return Admin1; }
            set {
                Admin1 = value;

            }}

        public static string UserEmailIs
        {
            get { return UserEmailIs1; }
            set
            {
                UserEmailIs1 = value;

            }
        }
      
        public static string GetIdOfCurrentUserByEmail(string email) {

            ApplicationUserManager userManager
        = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = userManager.FindByEmail(email);
            return user.Id;

        }







    }
}