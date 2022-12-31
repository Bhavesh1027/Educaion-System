using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Education_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Fname { get; set; }
        public string Lname { get; set; }
    }

    //public class ApplicationRole : IdentityRole
    //{
    //    public ApplicationRole() : base() { }
    //    public ApplicationRole(string roleName) : base(roleName) { }
    //}
  
    public class Course
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Course_Details { get; set; }
        public string Category { get; set; }
        public string Requirements { get; set; }
        public string Course_Syllabus { get; set; }
        public string Credits { get; set; }
        public string Duration { get; set; }
        public string Lessons { get; set; }
        public string seats { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
    public class cart
    {
        [Key]
        public int Cid { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<int> bil { get; set; }
        public string Cemail { get; set; }
        public Nullable<int> price { get; set; }
    }

    //public class Addcourse
    //{
    //    [Key]
    //    public string id { get; set; }
    //    public string UserId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string Image { get; set; }
    //}
    public class Mymodel
    {
        public List<Course> CourseList { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Education_System.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<Education_System.Models.cart> carts { get; set; }

        public System.Data.Entity.DbSet<Education_System.Models.RegisterViewModel> RegisterViewModels { get; set; }

        //public System.Data.Entity.DbSet<Education_System.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}