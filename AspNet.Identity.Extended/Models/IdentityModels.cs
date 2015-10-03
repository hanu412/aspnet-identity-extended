using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNet.Identity.Extended.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int,CustomUserIdentityLogin,CustomIdentityUserRole,CustomIdentityUserClaim>
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

   

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,CustomRole,int,CustomUserIdentityLogin,CustomIdentityUserRole,CustomIdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    /// <summary>
    /// Identity Role Implementation 
    /// </summary>
    public class CustomIdentityUserRole : IdentityUserRole<int>
    {


    }


    /// <summary>
    /// User Login Implementation - 3rd party Auth
    /// </summary>
    public class CustomUserIdentityLogin : IdentityUserLogin<int>
    {


    }

    /// <summary>
    /// User claims
    /// </summary>

    public class CustomIdentityUserClaim : IdentityUserClaim<int>
    {


    }

    public class CustomRole : IdentityRole<int,CustomIdentityUserRole>
    {


    }
    public class CustomIdentityUser : IdentityUser<int,CustomUserIdentityLogin,CustomIdentityUserRole,CustomIdentityUserClaim>
    {
    

       
    }



}