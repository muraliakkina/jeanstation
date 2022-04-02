using JeanStation.CartService.DAL;
using JeanStation.CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.CartService.Services
{
    public class CartServices : ICartService
    {
        private readonly ICartRepository _repository;
        public CartServices(ICartRepository repository)
        {
            this._repository = repository;
        }
        public Cart AddItemToCart(Cart Item)
        {
            try
            {
                return this._repository.AddItemToCart(Item);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Cart DeacreaseItemQuantity(int itemId,int userId)
        {
            try
            {
                return _repository.DecreaseQuantity(itemId,userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cart> GetCartItems(int UserId)
        {
            try
            {
                return this._repository.GetCartItems(UserId);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Cart IncreaseQuantity(int itemId, int userId, Item item)
        {
            try
            {
                return _repository.IncreaseQuantity(itemId,userId,item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveAllItemsFromCart(int UserId)
        {
            try
            {
                return _repository.RemoveAllItemsFromCart(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveItemfromCart(int UserId,int ItemId)
        {
            try
            {
                return this._repository.RemoveItemfromCart(UserId,ItemId);
            }
            catch (System.Exception)
            {
                return false;
            }

        }
    }
}
