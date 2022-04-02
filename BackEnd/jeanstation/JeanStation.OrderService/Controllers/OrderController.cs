using JeanStation.OrderService.Models;
using JeanStation.OrderService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeanStation.OrderService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            this._orderServices = orderServices;
        }
        // GET: api/<OrderController>
        //[Authorize(Roles = "User")]
        [HttpGet("{userId}")]
        public IActionResult GetAllOrdersByUser(int userId)
        {
            try
            {
                List<Order> orders = _orderServices.GetAllOrdersByUser(userId); 
                if(orders == null)
                {
                    return NotFound(orders);
                }
                else
                {
                    return Ok(orders);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                List<Order> orders = _orderServices.GetAllOrders();
                if (orders == null)
                {
                    return NotFound(orders);
                }
                else
                {
                    return Ok(orders);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("orderid/{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
               Order order = _orderServices.GetOrderById(id);
                if(order == null)
                {
                    return NotFound(false);
                }
                else
                {
                    return Ok(order);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // POST api/<OrderController>
        //[Authorize(Roles = "User")]
        [HttpPost("{userId}/Placeorder/{addressId}")]
        public async Task<IActionResult> PlaceOrder(int userId,int addressId)
        {
            try
            {
                using (HttpClient client = new HttpClient(), client1 = new HttpClient())
                {
                    string url1 = "https://jeanstationcartservice.azurewebsites.net";
                    client.BaseAddress = new Uri(url1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue(
                        "application/json"));
                    HttpResponseMessage responseMessageItem = await client.GetAsync("api/Cart/" + userId);
                    string itemStringContent = await responseMessageItem.Content.ReadAsStringAsync();
                    List<Cart> cartContent = JsonConvert.DeserializeObject<List<Cart>>(itemStringContent);

                    if (cartContent == null)
                    {
                        return NotFound("Please add items to the cart");
                    }
                    else
                    {
                        int totalPrice = 0;
                        int totalQuantity = 0;
                        foreach (Cart cart in cartContent)
                        {
                            totalPrice += (cart.ItemPrice * cart.ItemQuantity);
                            totalQuantity += 1;
                        }
                        Order order = new Order();
                        order.UserId = cartContent[0].UserId;
                        order.TotalProducts = totalQuantity;
                        order.TotalPrice = totalPrice;
                        order.OrderStatus = "Placed";
                        order.AddressId = addressId;
                        order.OrderCreatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString();
                        Order order1 = _orderServices.PlaceOrder(order);
                        if (order1 == null)
                        {
                            return BadRequest(order1);
                        }
                        else
                        {

                            // MultiItemsOrder multiItemsOrder = new MultiItemsOrder();
                            bool itemContent2 = false;
                            client1.BaseAddress = new Uri("https://jeanstationitemservice.azurewebsites.net");
                            for (int i = 0; i < totalQuantity; i++)
                            {
                                MultiItemsOrder multiItemsOrder = new MultiItemsOrder();


                                multiItemsOrder.UserId = cartContent[i].UserId;
                                multiItemsOrder.OrderId = order1.OrderId;
                                multiItemsOrder.ItemPrice = cartContent[i].ItemPrice;
                                multiItemsOrder.ItemQuantity = cartContent[i].ItemQuantity;
                                multiItemsOrder.ItemId = cartContent[i].ItemId;
                                //multiItemsOrder.Order = null;


                                _orderServices.AddMultiItemsOrders(multiItemsOrder);
                               
                                client1.DefaultRequestHeaders.Accept.Clear();
                                client1.DefaultRequestHeaders.Accept.Add(
                                 new MediaTypeWithQualityHeaderValue(
                                    "application/json"));
                                HttpResponseMessage responsItem = await client1.GetAsync("api/Item/GetItem/" + cartContent[i].ItemId);
                                string itemContent1 = await responsItem.Content.ReadAsStringAsync();
                                Item itemContent = JsonConvert.DeserializeObject<Item>(itemContent1);

                                itemContent.ItemStock -= cartContent[i].ItemQuantity;

                                client1.DefaultRequestHeaders.Accept.Clear();
                                client1.DefaultRequestHeaders.Accept.Add(
                                 new MediaTypeWithQualityHeaderValue(
                                    "application/json"));
                                var json = JsonConvert.SerializeObject(itemContent);
                                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                                HttpResponseMessage responseMessageItemEdit = await client1.PutAsync("api/Item/" + cartContent[i].ItemId,httpContent);
                                string itemStringContent1 = await responseMessageItemEdit.Content.ReadAsStringAsync();
                                itemContent2 = JsonConvert.DeserializeObject<bool>(itemStringContent1);

                            }

                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                             new MediaTypeWithQualityHeaderValue(
                                "application/json"));
                            HttpResponseMessage responseCartClear = await client.DeleteAsync("api/Cart/" + userId);
                            string cartClear = await responseCartClear.Content.ReadAsStringAsync();
                            bool cartClearContent = JsonConvert.DeserializeObject<bool>(cartClear);

                            if (cartClearContent)
                            {
                                return Ok(order1);
                            }
                            else
                            {
                                return BadRequest();
                            }
                           
                            
                           
                        }

                    }
                }

                
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT api/<OrderController>/5
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult EditOrderStatus(int id, [FromBody] string value)
        {

            bool check = _orderServices.EditOrderStatus(id, value);
            if (check)
            {
                return Ok(check);
            }
            else
            {
                return BadRequest(check);
            }
        }

        // Get api/<OrderController>/5
        
        [HttpGet("Items/Order/{id}")]
        public async Task<IActionResult> GetItemsInOrder(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    List<MultiItemsOrder> orderstatus = _orderServices.GetItemsInOrder(id);
                    client.BaseAddress = new Uri("https://jeanstationitemservice.azurewebsites.net");
                    List<Item> items = new List<Item>();

                    if( orderstatus.Count > 0)
                    {
                        for (int i = 0; i < orderstatus.Count; i++)
                        {
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                             new MediaTypeWithQualityHeaderValue(
                                "application/json"));
                            HttpResponseMessage responsItem = await client.GetAsync("api/Item/GetItem/" + orderstatus[i].ItemId);
                            string itemContent1 = await responsItem.Content.ReadAsStringAsync();
                            Item itemContent = JsonConvert.DeserializeObject<Item>(itemContent1);
                            items.Add(itemContent);
                        }
                        return Ok(items);
                    }
                    else return BadRequest(items);
                      
                }
                    
               
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("ReturnItem")]
        public IActionResult ReturnItem(ReturnOrder order)
        {
            try
            {
                ReturnOrder order1 = _orderServices.ReturnTheProduct(order);
                if(order1 == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(order);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
