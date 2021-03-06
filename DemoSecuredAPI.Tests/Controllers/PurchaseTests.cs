﻿using DemoSecuredAPI.Controllers;
using DemoSecuredAPI.Models.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;

namespace DemoSecuredAPI.Tests.Controllers
{
    [TestClass]
    public class PurchaseTests
    {
        // can't really test unauthenticated purchase here, since by the time the POST
        // hits the controller, we know we're authenticated and authorized

        [TestMethod]
        public void PostPurchase_ReturnsSame()
        {
            var repo = new MockItemRepository();
            var controller = new PurchaseController(repo);
            var itemName = "TunaMelt";
            var item = controller.Post(itemName) as CreatedAtRouteNegotiatedContentResult<IItem>;

            Assert.IsNotNull(item);
            Assert.AreEqual(item.RouteName, "GetItemByName");
            Assert.AreEqual(item.RouteValues["itemName"], item.Content.Name);
            Assert.AreEqual(item.Content.Name, itemName);
        }

        [TestMethod]
        public void PostPurchase_ReturnsPopulatedItem()
        {
            var repo = new MockItemRepository();
            var controller = new PurchaseController(repo);
            var itemName = "TunaMelt";
            var response = controller.Post(itemName) as CreatedAtRouteNegotiatedContentResult<IItem>;
            Assert.IsNotNull(response);

            var newItem = response.Content;
            Assert.AreEqual(newItem.Name, itemName);
            Assert.AreEqual(newItem.Description, "Tuna melt on rye");
            Assert.AreEqual(newItem.Price, 5);
        }

        [TestMethod]
        public void PostPurchase_DecrementsInventory()
        {
            var repo = new MockItemRepository();
            var startingCount = repo.GetInventory().Count;
            var controller = new PurchaseController(repo);
            var itemName = "TunaMelt";
            var item = controller.Post(itemName) as CreatedAtRouteNegotiatedContentResult<IItem>;
            var newCount = repo.GetInventory().Count;

            Assert.IsTrue(startingCount == (newCount + 1));
        }

        [TestMethod]
        public void PostPurchase_InvalidItemNameReturnsError()
        {
            var repo = new MockItemRepository();
            var controller = new PurchaseController(repo);
            var itemName = "NotAnItem";
            var result = controller.Post(itemName);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
