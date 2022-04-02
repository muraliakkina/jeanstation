using JeanStation.ItemService.Models;
using JeanStation.ItemService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JeanStation.ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            this._service = service;
        }
        //To Add items in Item table
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddItem([FromBody] Item item)
        {
            try
            {
                Item items = this._service.AddItem(item);
                if (items != null)
                {
                    return StatusCode(statusCode: 201, items);
                }
                else
                {
                    return StatusCode(statusCode: 500,items);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //[Authorize(Roles = "Admin")]
        //To Delete Items by Itemsid
        [HttpDelete("{ItemId}")]
        public IActionResult DeleteItem(int ItemId)
        {
            try
            {
                bool response = this._service.DeleteItem(ItemId);
                if (response)
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
        //To Update an Item properties
        //[Authorize(Roles = "Admin")]
        [HttpPut("{ItemId}")]
        public IActionResult UpdateItem(int ItemId, [FromBody] Item item)
        {
            try
            {
                bool response = this._service.UpdateItem(ItemId, item);
                if (response == true)
                {
                    return StatusCode(statusCode: 201, response);
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
        }//To Get All Items 
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                List<Item> items = this._service.GetAllItems();
                if (items != null)
                {
                    return StatusCode(statusCode: 200, items);
                }
                else
                {
                    return StatusCode(statusCode: 500);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //To Get An Item By Its ItemId
        [HttpGet("GetItem/{ItemId}")]
        public IActionResult GetItemById(int ItemId)
        {
            try
            {
                Item item = this._service.GetItemById(ItemId);
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
        //To get an item by its category
        [HttpGet("GetCategory/{category}")]
        public IActionResult GetItemByCategory(string category)
        {
            try
            {

                List<Item> item = this._service.GetItemByCategory(category);
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
        //To get an item by its name of brand
        [HttpGet("GetBrand/{Brand}")]
        public IActionResult GetItemByBrand(string Brand)
        {
            try
            {
                List<Item> item = this._service.GetItemByBrand(Brand);
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
        //to get an item by its type name
        [HttpGet("GetType/{type}")]
        public IActionResult GetItemByType(string type)
        {
            try
            {
                List<Item> item = this._service.GetItemByType(type);
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
        //to get an item in the price range
        [HttpGet("GetPrice/{MaxPrice, MinPrice}")]
        public IActionResult GetItemByPrice(int MaxPrice, int MinPrice)
        {
            try
            {
                List<Item> item = this._service.GetItemByPrice(MaxPrice, MinPrice);
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
        //to get items added after the date
        [HttpGet("GetItemsByDate")]
        public IActionResult GetItemByDateAdded( )
        {
            try
            {
                List<Item> item = this._service.GetItemByDateAdded();
                if (item != null)
                {
                    return StatusCode(statusCode: 200, item);
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
    }
}
