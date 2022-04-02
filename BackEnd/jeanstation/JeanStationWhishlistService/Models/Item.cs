using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemMaterial { get; set; }
        public string ItemCategory { get; set; }
        public DateTime DateAdded { get; set; }
        public int ItemPrice { get; set; }
        public string ItemColor { get; set; }
        public string ItemBrandName { get; set; }
        public string ItemType{ get; set; }
        public string ItemSize { get; set; }
        public int ItemStock { get; set; }
        public string ItemImage1 { get; set; }
        public string ItemImage2 { get; set; }
        public string ItemImage3 { get; set; }
        

    }
}
