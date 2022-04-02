using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.OrderService.Models
{
    public class MultiItemsOrder
    {
        [Key]
        public int MultiItemsId { get; set; }
        public int UserId { get; set; }
       
        public int ItemId { get; set;}
        
        public int ItemQuantity { get; set;}
        public double ItemPrice { get; set;}
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
