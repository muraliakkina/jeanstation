using JeanStation.CartService.Models;
using JeanStation.CartService.Services;
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

namespace JeanStation.CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        public CartController(ICartService service)
        {
            this._service = service;
        }
        //To get All Items From Cart 
        //[Authorize(Roles = "User")]
        [HttpGet("{UserId}")]
        public IActionResult GetAllItemsInCart(int UserId)
        {
            try
            {
                List<Cart> Items = this._service.GetCartItems(UserId).ToList();
                if (Items != null)
                {
                    return StatusCode(statusCode: 200, Items);
                }
                else
                {
                    return StatusCode(statusCode: 404);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //To Remove Items From Cart
        //[Authorize(Roles = "User")]
        [HttpDelete("{UserId}/{ItemId}")]
        public IActionResult RemoveItemsFromCart(int UserId,int ItemId)
        {
            try
            {

                
                bool response = this._service.RemoveItemfromCart(UserId, ItemId);
                if (response == true)
                {
                    return StatusCode(statusCode: 200, response);
                }
                else
                {
                    return StatusCode(statusCode: 404);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpDelete("{UserId}")]
        public IActionResult RemoveAllItemsFromCart(int UserId)
        {
            try
            {


                bool response = this._service.RemoveAllItemsFromCart(UserId);
                if (response == true)
                {
                    return StatusCode(statusCode: 200, response);
                }
                else
                {
                    return StatusCode(statusCode: 404);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPut("dec/{userId}/{itemId}")]
        public IActionResult EditItemQuantity(int userId, int itemId)
        {
            try
            {
                Cart response = this._service.DeacreaseItemQuantity(userId, itemId);
                if (response != null)
                {
                    return StatusCode(statusCode: 200, response);
                }
                else
                {
                    return StatusCode(statusCode: 204,response);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPut("{userId}/cart/{itemId}")]
        public async Task<IActionResult> EditIncreaseItemQuantity(int userId, int itemId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
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

                    Cart response = this._service.IncreaseQuantity(itemId, userId,itemContent);
                    if (response!= null)
                    {
                        return StatusCode(statusCode: 200, response);
                    }
                    else
                    {
                        return StatusCode(statusCode: 404, itemContent);
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        //To Add Items To Cart
        [HttpPost("{itemId}/{userId}")]
        public async Task<IActionResult> AddItemToCart(int itemId,int userId, int Qty = 1)
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

                    Cart cartItem = new Cart();
                    cartItem.ItemSize = itemContent.ItemSize;
                    cartItem.ItemId = itemContent.ItemId;
                    cartItem.UserId = userContent.UserId;
                    cartItem.ItemImg1 = itemContent.ItemImage1;
                    cartItem.ItemName = itemContent.ItemName;
                    cartItem.ItemBrandName = itemContent.ItemBrandName;
                    
                    cartItem.ItemQuantity = cartItem.ItemQuantity + Qty;
                    cartItem.ItemPrice = itemContent.ItemPrice;
                    if(cartItem.ItemQuantity <= itemContent.ItemStock)
                    {
                        Cart Items = this._service.AddItemToCart(cartItem);
                        if (Items != null)
                        {
                           /* if (itemContent.ItemStock >= cartItem.ItemQuantity)
                            {*/
                                return StatusCode(statusCode: 200, Items);
                            
                            

                        }
                        else 
                        {
                            return StatusCode(statusCode: 204, "Item Already added to the cart. Increase the Quantity in the Cart");
                        }
                    }
                    else
                    {
                        return StatusCode(statusCode: 204, $"Choose proper quantity. Stock left: {itemContent.ItemStock}");
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
