using JeanStation.ItemService.DAL;
using JeanStation.ItemService.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.ItemService.Service
{
    public class ItemServices : IItemService
    {
        private readonly IItemRepository _repository;
        public ItemServices(IItemRepository repository)
        {
            this._repository = repository;
        }
        //To Add an Item by ItemId
        public Item AddItem(Item item)
        {
            try
            {
                return this._repository.AddItem(item);
                
            }
            catch (System.Exception)
            {
                return null;
            }
           
        }
        //To Delete an Item by ItemId
        public bool DeleteItem(int itemId)
        {

            try
            {
                return this._repository.DeleteItem(itemId);               
            }
            catch (System.Exception)
            {
                return false;
            }
           
        }
        //To Update an Item by ItemId
        public bool UpdateItem(int itemId, Item item)
        {
            try
            {
                return this._repository.UpdateItem(itemId, item);
                 
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        //To get all Items 
        public List<Item> GetAllItems()
        {
            try
            {
                return this._repository.GetAllItems(); ;
            }
            catch(System.Exception)
            {
                return null;
            }
        }
        //To get Items Based on their their ItemId
        public Item GetItemById(int itemId)
        {
            try
            {
                return this._repository.GetItemById(itemId);

            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To get Items Based on their Category
        public List<Item> GetItemByCategory(string category)
        {
            try
            {
                return this._repository.GetItemByCategory(category);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To get Items Based on their Brand Name
        public List<Item> GetItemByBrand(string brand)
        {
            try
            {
                return this._repository.GetItemByBrand(brand);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        // to Get the Items Based on their type
        public List<Item> GetItemByType(string type)
        {
            try
            {
                return this._repository.GetItemByType(type);
            }
            catch (System.Exception)
            {
                return null;
            }
        
        }
        //To Get Items Based on a price range
        public List<Item> GetItemByPrice(int MaxPrice, int MinPrice)

        {
            try
            {
                return this._repository.GetItemByPrice(MaxPrice, MinPrice);
            }
            catch (System.Exception)
            {
                return null;
            } 
        }
        //To Get Items By their Date Of Registration into the Database
        public List<Item> GetItemByDateAdded( )
        {
            try
            {
                return this._repository.GetItemByDateAdded();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
