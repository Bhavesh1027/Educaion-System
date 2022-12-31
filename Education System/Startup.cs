using Education_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Education_System.Startup))]
namespace Education_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //PopulateUserAndRoles();
        }
        //public void PopulateUserAndRoles()
        //{
        //    var db = new ApplicationDbContext();

        //    // Populating Roles
        //    if(!db.Roles.Any(x => x.Name == Role.RoleAdmin))
        //    {
        //        db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Role.RoleAdmin));
        //        db.SaveChanges();
        //    }

        //    if (!db.Roles.Any(x => x.Name == Role.RoleUser))
        //    {
        //        db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Role.RoleUser ));
        //        db.SaveChanges();

        //    }
        //    // Populate user
        //    if (!db.Users.Any(x => x.UserName == "admin@gmail.com"))
        //    {
        //        var userstore = new UserStore<ApplicationUser>(db);
        //        var userManager = new ApplicationUserManager(userstore);

        //        var roleStore = new RoleStore<IdentityRole>(db);
        //        var roleManager = new RoleManager<IdentityRole>(roleStore);

        //        var newUser = new ApplicationUser
        //        {
        //            Email = "admin@gmail.com",
        //            UserName = "admin@gmail.com"
        //        };

        //        userManager.Create(newUser, "Admin@123");
        //        userManager.AddToRole(newUser.Id, Role.RoleAdmin);
        //        db.SaveChanges();
        //    }

        //    if (!db.Users.Any(x => x.UserName == "user@gmail.com"))
        //    {
        //        var userstore = new UserStore<ApplicationUser>(db);
        //        var userManager = new ApplicationUserManager(userstore);

        //        var roleStore = new RoleStore<IdentityRole>(db);
        //        var roleManager = new RoleManager<IdentityRole>(roleStore);

        //        var newUser = new ApplicationUser
        //        {
        //            Email = "user@gmail.com",
        //            UserName = "user@gmail.com"
        //        };

        //        userManager.Create(newUser, "User@123");
        //        userManager.AddToRole(newUser.Id, Role.RoleAdmin);
        //        db.SaveChanges();
        //    }
        //}
    }
}
