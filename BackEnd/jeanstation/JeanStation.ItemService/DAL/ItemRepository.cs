using JeanStation.ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.ItemService.DAL
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemDbContext _DbContext;
        public ItemRepository(ItemDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }
        //To add an Item
        public Item AddItem(Item item)
        {
            try
            {
                this._DbContext.Add(item);
                this._DbContext.SaveChanges();
                return item;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To Delete an Item
        public bool DeleteItem(int itemId)
        {
            try
            {
                Item item = this._DbContext.Items.Find(itemId);
                if (item != null)
                {
                    this._DbContext.Items.Remove(item);
                    this._DbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        //To update an Item 
        public bool UpdateItem(int itemId, Item item)
        {
            try
            {
                Item itemAtId = this._DbContext.Items.Find(itemId);
                if (itemAtId != null)
                {
                    itemAtId.ItemBrandName = item.ItemBrandName;
                    itemAtId.ItemCategory = item.ItemCategory;
                    itemAtId.ItemColor = item.ItemColor;                    
                    itemAtId.ItemImage1 = item.ItemImage1;
                    itemAtId.ItemImage2 = item.ItemImage2;
                    itemAtId.ItemImage3 = item.ItemImage3;
                    itemAtId.ItemMaterial = item.ItemMaterial;
                    itemAtId.ItemName = item.ItemName;
                    itemAtId.ItemPrice = item.ItemPrice;
                    itemAtId.ItemSize = item.ItemSize;
                    itemAtId.ItemStock = item.ItemStock;
                    itemAtId.ItemType = item.ItemType;
                    
                    this._DbContext.Items.Update(itemAtId);
                    this._DbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        //To Get All Items In a List
        public List<Item> GetAllItems()
        {
            try
            {
                return this._DbContext.Items.ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To Get An Element By Id
        public Item GetItemById(int itemId)
        {
            try
            { 
                Item item = this._DbContext.Items.Find(itemId);
                return item;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To Get Items By Category Name
        public List<Item> GetItemByCategory(string category)
        {
            try
            {
                return this._DbContext.Items.Where(u => u.ItemCategory == category).ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
           
        }
        //To Get Items By Brand Name
        public List<Item> GetItemByBrand(string brand)
        {
            try
            {
                return this._DbContext.Items.Where(u => u.ItemBrandName == brand).ToList();

            }
            catch (System.Exception)
            {
                return null;
            }
        }
        //To Get Items By Type
        public List<Item> GetItemByType(string type)
        {
            try 
            {
                return this._DbContext.Items.Where(u => u.ItemType == type).ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        //Get Item By Price Range
        public List<Item> GetItemByPrice(int MaxPrice, int MinPrice)
        {
            try
            {
                return this._DbContext.Items.Where(u => u.ItemPrice <= MaxPrice && u.ItemPrice >= MinPrice).ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }
    //    Get a List of Items With date 
        public List<Item> GetItemByDateAdded()
        {
            try
            {
                DateTime date = DateTime.Now.Date;
                return _DbContext.Items.Where(u => u.DateAdded.AddDays(7).Date >= date).ToList();
               
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /*public List<Item> ItemsFilter()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}

