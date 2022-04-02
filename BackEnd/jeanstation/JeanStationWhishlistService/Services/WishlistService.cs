using JeanStation.WishlistService.DAL;
using JeanStation.WishlistService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _repository;
        public WishlistService(IWishlistRepository repository)
        {
            this._repository = repository;
        }
        public Wishlist AddItemToWishlist(Wishlist Item)
        {
            try
            {
                return this._repository.AddItemToWishlist(Item);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public List<Wishlist> GetWishlistItems(int UserId)
        {
            try
            {
                return this._repository.GetWishlistItems(UserId);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Wishlist RemoveItemfromWishlist(int userId, int ItemId)
        {
            try
            {
                return this._repository.RemoveItemfromWishlist(userId,  ItemId);
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        
    }
}
