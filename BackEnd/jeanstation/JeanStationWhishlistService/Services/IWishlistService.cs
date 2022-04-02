using JeanStation.WishlistService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.Services
{
    public interface IWishlistService
    {
        Wishlist AddItemToWishlist(Wishlist Item);
        Wishlist RemoveItemfromWishlist(int userId, int ItemId);
        List<Wishlist> GetWishlistItems(int UserId);
       
    }
}