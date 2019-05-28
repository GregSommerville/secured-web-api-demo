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
    }
}
