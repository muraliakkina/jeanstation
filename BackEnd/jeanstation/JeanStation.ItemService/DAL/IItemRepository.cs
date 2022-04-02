using JeanStation.ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeanStation.ItemService.DAL
{
    public interface IItemRepository
    {
        Item AddItem(Item item);
        bool DeleteItem(int ItemId);
        bool UpdateItem(int ItemId, Item item);
        List<Item> GetAllItems();
        Item GetItemById(int itemId);
        List<Item> GetItemByCategory(string category);

        List<Item> GetItemByBrand(string brand);
        List<Item> GetItemByType(string type);
        List<Item> GetItemByPrice(int MaxPrice, int MinPrice);
        List<Item> GetItemByDateAdded();


    }
}
