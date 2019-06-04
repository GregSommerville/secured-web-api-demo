using DemoSecuredAPI.Controllers;
using DemoSecuredAPI.Models.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace DemoSecuredAPI.Tests.Controllers
{
    [TestClass]
    public class ItemsTests  
    {
        [TestMethod]
        public void GetItems_ReturnsCorrectNumber()
        {
            var repo = new MockItemRepository();
            var controller = new ItemsController(repo);
            var data = controller.Get() as OkNegotiatedContentResult<List<IItem>>;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Content);
            Assert.IsTrue(data.Content.Count == 4);
        }

        [TestMethod]
        public void GetItems_WorksWithEmptyInventory()
        {
            var repo = new MockItemRepository();
            repo.Clear();

            var controller = new ItemsController(repo);
            var data = controller.Get() as OkNegotiatedContentResult<List<IItem>>;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Content);
            Assert.IsTrue(data.Content.Count == 0);
        }

        [TestMethod]
        public void GetItems_ReturnsExpectedProducts()
        {
            var repo = new MockItemRepository();
            var controller = new ItemsController(repo);
            var data = controller.Get() as OkNegotiatedContentResult<List<IItem>>;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Content);

            var items = data.Content;
            Assert.IsTrue(items.Exists(i => i.Name == "ChickenSoup"));
            Assert.IsTrue(items.Exists(i => i.Name == "Caeser"));
            Assert.IsTrue(items.Exists(i => i.Name == "TunaMelt"));
            Assert.IsTrue(items.Exists(i => i.Name == "SweetFries"));
        }

        [TestMethod]
        public void GetItems_ReturnsPopulatedProduct()
        {
            var repo = new MockItemRepository();
            var controller = new ItemsController(repo);
            var data = controller.Get() as OkNegotiatedContentResult<List<IItem>>;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Content);

            var items = data.Content;
            var soup = items.Find(i => i.Name == "ChickenSoup");

            Assert.IsNotNull(soup);
            Assert.IsNotNull(soup.Description);
            Assert.IsNotNull(soup.Price);
        }
    }
}
