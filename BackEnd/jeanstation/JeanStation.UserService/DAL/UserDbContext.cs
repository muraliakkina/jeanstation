using JeanStation.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace JeanStation.UserService.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            *//*modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddress");
                entity.Property(s => s.City);
                entity.Property(s => s.District).IsRequired().HasMaxLength(20);
                entity.Property(s => s.DoorNo).HasMaxLength(200).IsRequired();
                entity.Property(s => s.Locality).IsRequired().HasMaxLength(20);
                entity.Property(s => s.Pincode).IsRequired().HasMaxLength(20);
                entity.Property(s => s.State).IsRequired().HasMaxLength(20);
                entity.Property(s => s.StreetName).IsRequired().HasMaxLength(20);
                entity.Property(s => s.UserId).IsRequired().HasMaxLength(20);

            });*//*
        }*/

    }
}
