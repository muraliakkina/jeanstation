using JeanStation.CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.CartService.DAL
{
    public interface ICartRepository
    {
        Cart AddItemToCart(Cart? Item);
        bool RemoveItemfromCart(int UserId,int ItemId);
        List<Cart> GetCartItems(int UserId);
        Cart IncreaseQuantity(int itemId, int userId, Item item);
        Cart DecreaseQuantity(int itemId,int userId);
        bool RemoveAllItemsFromCart(int userId);
    }
}
