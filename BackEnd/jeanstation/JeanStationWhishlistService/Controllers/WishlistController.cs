using JeanStation.WishlistService.Models;
using JeanStation.WishlistService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JeanStation.WishListService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _service;
        public WishlistController(IWishlistService wishlistService)
        {
            this._service = wishlistService;
        }
        //To get All Items From Wishlist 
        //[Authorize(Roles = "User")]
        [HttpGet("{UserId}")]
        public IActionResult GetAllItemsInWishlist(int UserId)
        {
            try
            {
                List<Wishlist> Items = this._service.GetWishlistItems(UserId).ToList();
                if (Items == null)
                {
                     return StatusCode(statusCode: 404);
                }
                else
                {
                    return StatusCode(statusCode: 200, Items);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //To Remove Items From Wishlist
        //[Authorize(Roles = "User")]
        [HttpDelete("{UserId}/del/{ItemId}")]
        public IActionResult RemoveItemsFromCart(int UserId, int ItemId)
        {
            try
            {
                Wishlist response = this._service.RemoveItemfromWishlist(UserId, ItemId);
                if (response == null)
                {
                    return StatusCode(statusCode: 204, response);
                }
                else if(response != null)
                {
                    return StatusCode(statusCode: 200,response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //To Add Items To Wishlist
        //[Authorize(Roles = "User")]
        [HttpPost("{itemId}/{userId}")]
        public async Task<IActionResult> AddItemToWishlist(int itemId, int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient(), client1 = new HttpClient())
                {
                    string url1 = "https://jeanstationitemservice.azurewebsites.net";
                    client.BaseAddress = new Uri(url1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue(
                        "application/json"));
                    HttpResponseMessage responseMessageItem = await client.GetAsync("api/Item/GetItem/" + itemId);
                    string itemStringContent = await responseMessageItem.Content.ReadAsStringAsync();
                    Item itemContent = JsonConvert.DeserializeObject<Item>(itemStringContent);

                    client1.BaseAddress = new Uri("https://jeanstationuserservice.azurewebsites.net");
                    client1.DefaultRequestHeaders.Accept.Clear();
                    client1.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue(
                        "application/json"));
                    HttpResponseMessage userMessage = await client1.GetAsync("api/User/" + userId);
                    string userStringContent = await userMessage.Content.ReadAsStringAsync();
                    User userContent = JsonConvert.DeserializeObject<User>(userStringContent);
                    Wishlist wishlist = new Wishlist();
                    wishlist.ItemId = itemContent.ItemId;
                    wishlist.UserId = userContent.UserId;
                    wishlist.ItemImg1 = itemContent.ItemImage1;
                    wishlist.ItemImg2 = itemContent.ItemImage2;
                    wishlist.ItemImg3 = itemContent.ItemImage3;
                    wishlist.ItemPrice = itemContent.ItemPrice;
                    wishlist.ItemName = itemContent.ItemName;
                    wishlist.ItemBrandName = itemContent.ItemBrandName;

                    Wishlist Items = this._service.AddItemToWishlist(wishlist);
                    if (Items != null)
                    {
                        return StatusCode(statusCode: 200, Items);
                    }
                    else if(Items == null)
                    {
                        return StatusCode(statusCode: 204,"Item Already added to the wishlist");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }
        
        
    }
}
