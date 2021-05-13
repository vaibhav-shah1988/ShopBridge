using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge.DAL.Repositories;
using System;
using NUnit.Framework;
using ShopBridge.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using ShopBridge.Controllers;
using Assert = NUnit.Framework.Assert;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShopBridge.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IInventoryRepository> _inventoryRepository;

        public UnitTest1()
        {
            _inventoryRepository = new Mock<IInventoryRepository>();
        }

        [SetUp]
        public void SetUp()
        {
            
        }

        private static IEnumerable<Inventory> GetInventory()
        {
            IEnumerable<Inventory> items = new List<Inventory>
            {
                    new Inventory {Id=1,Name="TestName1",Description="TestDesc1",Price=10 },
                    new Inventory {Id=2,Name="TestName2",Description="TestDesc2",Price=20 },
                    new Inventory {Id=3,Name="TestName3",Description="TestDesc3",Price=30 }
            };

            return items.AsEnumerable();
        }

        [TestMethod]
        public void GetAllInvetory()
        {
            var items = GetInventory();
            _inventoryRepository.Setup(x => x.GetAllInventory()).Returns(items.AsQueryable());

            InventoryController controller = new InventoryController(_inventoryRepository.Object);

            var listItems = controller.GetAllInventory();

            Assert.AreEqual(3, listItems.Count(),"Wrong Count");

        }

        [TestMethod]
        public void GetAllInvetorybyId()
        {
            var items = GetInventory();
            _inventoryRepository.Setup(x => x.GetInventory(1)).Returns(items.Where(x=>x.Id == 1).FirstOrDefault());

            var controller = new InventoryController(_inventoryRepository.Object);

            var  Item = controller.GetInventory(1);
            var newItem = (System.Web.Http.Results.OkNegotiatedContentResult<ShopBridge.DAL.Entities.Inventory>)Item;
            Assert.AreEqual("TestName1", newItem.Content.Name, "Name not equal");
            Assert.AreEqual("TestDesc1", newItem.Content.Description, "description not equal");
            Assert.AreEqual(10, newItem.Content.Price, "price not equal");
        }

        [TestMethod]
        public void DeleteInventory()
        {
            var items = GetInventory();
            _inventoryRepository.Setup(x => x.DeleteInventory(1));

            var controller = new InventoryController(_inventoryRepository.Object);

            var Item = controller.DeleteInventory(1);
            
            Assert.IsInstanceOf(typeof(System.Web.Http.Results.OkResult), Item);
        }

        [TestMethod]
        public void PostInventory()
        {
            var controller = new InventoryController(_inventoryRepository.Object);

            IHttpActionResult result = controller.PostInventory(new Inventory { Id = 4, Name = "TestName4", Description = "TestDesc4", Price = 40});

            Assert.IsInstanceOf(typeof(OkResult), result);
        }
    }
}
