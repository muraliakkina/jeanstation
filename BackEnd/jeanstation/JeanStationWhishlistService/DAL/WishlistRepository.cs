using JeanStation.WishlistService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.WishlistService.DAL
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly WishlistDbContext _context;
        public WishlistRepository(WishlistDbContext context)
        {
            this._context = context;
        }
        //to add Items To the Wishlist
        public Wishlist AddItemToWishlist(Wishlist Item)
        {
            try
            {
                Wishlist wishlist = _context.Wishlists.Where(w =>w.ItemId == Item.ItemId && w.UserId == Item.UserId).FirstOrDefault();
                if(wishlist == null)
                {
                    this._context.Wishlists.Add(Item);
                    this._context.SaveChanges();
                    return Item;
                }
                else
                {
                    return null;
                }
                
            }
            catch(System.Exception)
            {
                return null;
            }
        }
        //To get the List of all the Items in the Wishlist of a particular user
        public List<Wishlist> GetWishlistItems(int UserId)
        {

            try
            {
                List<Wishlist> wishlists = this._context.Wishlists.Where(u => u.UserId==UserId).ToList();
                if (wishlists == null)
                {
                    return null;
                }
                else
                {
                    return wishlists;
                }
               
            }
            catch (System.Exception)
            {
                //return null;
                throw;
            }
        }
        //To Remove items From Wishlist 
        public Wishlist RemoveItemfromWishlist(int userId, int ItemId)
        {
            try
            {
                Wishlist wishlist = this._context.Wishlists.Where(u => u.UserId == userId && u.ItemId == ItemId).SingleOrDefault();
                if(wishlist == null)
                {
                    return null;
                }
                else
                {
                    this._context.Wishlists.Remove(wishlist);
                    this._context.SaveChanges();
                    return wishlist;
                }
                
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
    }
}
