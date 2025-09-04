using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }


        public DbSet<Room>Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> sendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> workLocations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
         .ToTable("Rooms", tb =>
         {
             tb.HasTrigger("RoomDecrease");
             tb.HasTrigger("RoomIncrease");
         });
            modelBuilder.Entity<Staff>()
        .ToTable("Staffs", tb =>
         {
             tb.HasTrigger("StaffDecrease");
             tb.HasTrigger("StaffIncrease");
         });
         modelBuilder.Entity<Guest>().ToTable("Guests", tb =>
         {
             tb.HasTrigger("GuestDecrease");
             tb.HasTrigger("GuestIncrease");
         });
        }
    }
}
