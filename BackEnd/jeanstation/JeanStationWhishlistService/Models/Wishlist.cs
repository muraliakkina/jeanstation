using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.Models
{
    public class Wishlist
    {
        
        public int UserId { get; set; }
        public int WishlistId { get; set; }
       
        public int ItemId  { get; set; }
        public string ItemName { get; set; }
        public string ItemBrandName { get; set; }
        public int ItemPrice { get; set; }

        public string ItemImg1 { get; set; }
        public string ItemImg2 { get; set; }
        public string ItemImg3 { get; set; }
    }
}