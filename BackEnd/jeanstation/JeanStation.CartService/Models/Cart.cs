using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.CartService.Models
{
    public class Cart
    {
        public int CartId { get; set; }
 
        public int UserId { get; set; }
       
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemSize { get; set; }
        public int ItemPrice { get; set; }
        public string ItemImg1 { get; set; }
        public string ItemName { get; set; }
        public string ItemBrandName { get; set; }
    }
}
