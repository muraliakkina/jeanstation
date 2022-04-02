using JeanStation.CartService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.CartService.DAL
{
    public class CartDbContext:DbContext
    {
        public CartDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(s => s.CartId);
                entity.Property(s => s.ItemId).IsRequired();
                entity.Property(s => s.ItemQuantity).IsRequired();
                entity.Property(s => s.UserId).IsRequired();  
            });
        }

    }
}
