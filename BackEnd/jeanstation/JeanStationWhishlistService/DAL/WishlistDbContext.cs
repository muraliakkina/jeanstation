using JeanStation.WishlistService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.DAL
{
    public class WishlistDbContext:DbContext
    {
        public WishlistDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Wishlist> Wishlists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wishlist>(entity =>
            {
               
                entity.HasKey(s => s.WishlistId);
                entity.Property(s => s.UserId).IsRequired();
                entity.Property(s => s.ItemId).IsRequired();
                
              
            });
        }

    }
}
