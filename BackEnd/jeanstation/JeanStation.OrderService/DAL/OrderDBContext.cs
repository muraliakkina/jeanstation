using JeanStation.OrderService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JeanStation.OrderService.DAL
{
    public class OrderDBContext: DbContext
    {
        public OrderDBContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ReturnOrder> ReturnOrders  { get; set; }
        public DbSet<MultiItemsOrder> MultiItemsOrders { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {*/
           /* modelBuilder.Entity<Order>(entity =>
            {
                
                
                entity.Property<DateTime>(s => s.OrderCreatedAt);
            });*/
            /*modelBuilder.Entity<ReturnOrder>(entity =>
            {
                
                entity.Property<DateTime>(s => s.ReturnDate);
                
            });*/
            /*modelBuilder.Entity<MultiItemsOrder>(entity =>
            {
                
                entity.HasKey(s => s.MultiItemsId);
                entity.Property(s => s.ItemId).IsRequired();
                entity.Property(s => s.ItemPrice).IsRequired();
                entity.Property(s => s.ItemQuantity).HasMaxLength(20);
                entity.Property(s => s.UserId).HasMaxLength(20);

            });*/
        /*}*/

    }
}
