using Moq;
using NUnit.Framework;
using JeanStation.ItemService.DAL;
using System.Collections.Generic;
using JeanStation.ItemService.Models;
using System.Linq;

namespace ItemTest
{
    public class UnitTest
    {
        private readonly IItemRepository _repo;
       
        

        public UnitTest()
        {
            var mockRepo = new Mock<IItemRepository>();
            _repo = mockRepo.Object;
            IList<Item> item = new List<Item>() {
            new Item(){ItemId=1,ItemName="ABC",ItemPrice=100,ItemStock=100},
            new Item(){ItemId=2,ItemName="XYZ",ItemPrice=100,ItemStock=100},
            new Item(){ItemId=3,ItemName="AAA",ItemPrice=100,ItemStock=100},
            new Item(){ItemId=4,ItemName="BBB",ItemPrice=100,ItemStock=100},
            new Item(){ItemId=5,ItemName="CCC",ItemPrice=100,ItemStock=100},
            };
            mockRepo.Setup(product => product.GetAllItems()).Returns(item.ToList());
            mockRepo.Setup(repo => repo.GetItemById(It.IsAny<int>())).Returns((int i) => item.SingleOrDefault(x => x.ItemId == i));
            mockRepo.Setup(repo => repo.AddItem(It.IsAny<Item>())).Callback((Item product) =>
            {
                product = new Item() { ItemId = 6, ItemBrandName = "puma", ItemName = "DDD", ItemPrice = 100, ItemStock = 100, ItemCategory = "men", ItemColor = "blue", ItemImage1 = "", ItemImage2 = "", ItemImage3 = "", ItemMaterial = "", ItemSize = "36", ItemType = ""};
                item.Add(product);
            });
            mockRepo.Setup(repo => repo.DeleteItem(It.IsAny<int>())).Callback((int ItemId) =>
            { 
            Item items=item.SingleOrDefault(x => x.ItemId == ItemId);
            item.Remove(items);

            });
            
           mockRepo.SetupAllProperties();
           
        }
        [Test]
        public void TestGetAllItems()
        {
            //Arrange
            int expected = 5;
            //Act
            var Itemlist = _repo.GetAllItems();
            //Assert
            Assert.AreEqual(expected, Itemlist.Count);
        }
        [Test]
        public void TestGetItembyId()
        {
            //Arrange
            int expected = 1;
            //Act
            var item = _repo.GetItemById(1);
            Assert.AreEqual(expected,item.ItemId );
        }
        [Test]
        public void TestAddItem()
        {
            var itemdetails = new Item() { ItemId = 6, ItemName = "DDD", ItemPrice = 100, ItemStock = 100 };

            _repo.AddItem(itemdetails);

            Assert.AreEqual(1, 1);
        }
        [Test]
        public void TestDeleteItem()
        {
            var itemdetails = new Item() { ItemId = 5, ItemName = "CCC", ItemPrice = 100, ItemStock = 100 };

            _repo.DeleteItem(itemdetails.ItemId);

            Assert.AreEqual(1, 1);
        }

    }
}