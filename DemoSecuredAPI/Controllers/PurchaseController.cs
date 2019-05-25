using DemoSecuredAPI.Models.DAL;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoSecuredAPI.Controllers
{
    [Authorize]
    public class PurchaseController : ApiController
    {
        // allow dependency injection (via constructor) to pass in data store
        private IItemRepository dataStore = new ItemRepository();

        public PurchaseController() {}
        public PurchaseController(IItemRepository repository)
        {
            dataStore = repository;
        }

        // POST api/purchase/itemName
        [ResponseType(typeof(IItem))]
        public IHttpActionResult Post(string itemName)
        {
            // in case we need the request API key, we get it this way:
            // string apiKey = RequestContext.Principal.Identity.Name;

            var item = dataStore.Buy(itemName);
            if (item == null)
                return BadRequest("Invalid item name");
            else
                return CreatedAtRoute("DefaultApi", new { id = item.Name }, item);
        }
    }
}
