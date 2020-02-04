﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebParkingMVC.Models
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
    }

    //Code Added by Me
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<LibraryWebParking.Model.Parkings> Parkings { get; set; }

        //public System.Data.Entity.DbSet<LibraryWebParking.Model.ParkingTypes> ParkingTypes { get; set; }

        //public System.Data.Entity.DbSet<LibraryWebParking.Model.spgetAvailableparkingsType_Result> spgetAvailableparkingsType_Result { get; set; }

        //public System.Data.Entity.DbSet<WebParkingMVC.Models.BookRoomModel> BookRooms { get; set; }

        //public System.Data.Entity.DbSet<LibraryWebParking.Model.FullBookRoomModel> FullBookRoomModels { get; set; }
    }
}