using DemoSecuredAPI.Controllers;
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
    }
}
