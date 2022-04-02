using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.OrderService.Models
{
    public class ReturnOrder
    {
       
        
        [Key]
        public string ReturnOrderId { get; set;}
       
        public string ReturnReason { get; set;}
       
        public int ItemId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
