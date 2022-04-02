using Microsoft.EntityFrameworkCore;
using JeanStation.ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.ItemService.DAL
{
    public class ItemDbContext:DbContext
    {
        public ItemDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(s => s.ItemId);
                entity.Property(s => s.ItemId);
                entity.Property(s => s.ItemBrandName).IsRequired().HasMaxLength(200);
                entity.Property(s => s.ItemCategory).IsRequired().HasMaxLength(200);
                entity.Property(s => s.ItemColor).IsRequired().HasMaxLength(200);
                entity.Property(s => s.ItemImage1).IsRequired().HasMaxLength(10000);
                entity.Property(s => s.ItemImage2).IsRequired().HasMaxLength(10000);
                entity.Property(s => s.ItemImage3).IsRequired().HasMaxLength(10000); ;
                entity.Property(s => s.ItemMaterial).IsRequired().HasMaxLength(20);
                entity.Property(s => s.ItemName).IsRequired().HasMaxLength(1000);
                entity.Property(s => s.ItemPrice).IsRequired().HasMaxLength(20);
                entity.Property(s => s.ItemSize).IsRequired().HasMaxLength(20);
                entity.Property(s => s.ItemStock).IsRequired();
                entity.Property(s => s.ItemType).IsRequired().HasMaxLength(200);
                entity.Property(s => s.ItemDescription).IsRequired().HasMaxLength(3000);
                entity.Property<DateTime>(s => s.DateAdded);
            });
        }

    }
}
