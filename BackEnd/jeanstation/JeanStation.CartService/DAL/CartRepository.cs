using JeanStation.CartService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JeanStation.CartService.DAL
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _context;
        public CartRepository(CartDbContext context)
        {
            this._context = context;
        }
        //to add Items To the Cart 
        public Cart AddItemToCart(Cart Item)
        {
            try
            {
                Cart cart = _context.Carts.Where(s=>s.ItemId == Item.ItemId && s.UserId == Item.UserId).SingleOrDefault();
                if (cart == null )
                {
                    this._context.Carts.Add(Item);
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

        public Cart DecreaseQuantity(int userId, int itemId)
        {
            try
            {
                Cart cart = _context.Carts.SingleOrDefault(s => s.ItemId == itemId && s.UserId == userId);
                if(cart == null)
                {
                    return null;
                }
                else if (cart.ItemQuantity > 1 && cart != null)
                {
                    cart.ItemQuantity = cart.ItemQuantity - 1;
                    _context.Carts.Update(cart);
                    _context.SaveChanges();
                    return cart;
                }
                else if(cart.ItemQuantity == 1 && cart != null)
                {
                    _context.Carts.Remove(cart);
                    _context.SaveChanges();
                    return null;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //To get the List of all the Items in the cart of a particular user
        public List<Cart> GetCartItems(int UserId)
        {

            try
            {
                List<Cart> cart = this._context.Carts.Where(u => u.UserId==UserId).ToList();
                return cart;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public   Cart IncreaseQuantity(int itemId ,int userId, Item item )
        {
            try
            {
                Cart cart = _context.Carts.Single(u => u.ItemId == itemId && u.UserId == userId);
                //Cart carts = _context.Carts.Where(s => s.ItemId == itemId).Where(s => s.UserId == userId);
                //Cart cart = new Cart();
                /*foreach (Cart c in carts)
                {
                    if (c.ItemId == itemId && c.UserId == userId)
                    {
                        cart = c;
                    }
                }*/
                /*if (cart == null)
                {
                    return null;
                }*/
                if (cart.ItemQuantity < item.ItemStock)
                    {

                        cart.ItemQuantity = cart.ItemQuantity + 1;
                        this._context.Carts.Update(cart);
                        this._context.SaveChanges();
                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                

                 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveAllItemsFromCart(int userId)
        {
            try
            {
                List<Cart> carts = _context.Carts.Where(s => s.UserId == userId).ToList();
                if(carts == null)
                {
                    return false;
                }
                else
                {
                    foreach (Cart cart in carts)
                    {
                        _context.Carts.Remove(cart);
                        _context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //To Remove items From Cart  
        public bool RemoveItemfromCart(int UserId,int ItemId)
        {
            try
            {
                Cart cart = this._context.Carts.SingleOrDefault(u => u.ItemId == ItemId && u.UserId == UserId );
                
                    this._context.Carts.Remove(cart);

                    this._context.SaveChanges();
                    return true;
     
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
