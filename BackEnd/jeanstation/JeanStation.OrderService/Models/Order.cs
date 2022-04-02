using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.OrderService.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
  
        public int UserId { get; set; }
      
        public int AddressId { get; set; }
        
        [MaxLength(1000)]
        public string OrderCreatedAt { get; set; }
        public int TotalProducts { get; set; }
        public int TotalPrice { get; set; }


    }
}
