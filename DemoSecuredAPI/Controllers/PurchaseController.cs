using DemoSecuredAPI.Models.DAL;
using DemoSecuredAPI.Models.RequestHandlers;
using System.Web.Http;

namespace DemoSecuredAPI.Controllers
{
    public class PurchaseController : ApiController
    {
        // dependency injection (via constructor) to pass in data store
        private IItemRepository dataStore = new ItemRepository();

        public PurchaseController() { }
        public PurchaseController(IItemRepository repository)
        {
            dataStore = repository;
        }

        // POST api/purchase/itemName
        [Authorize]
        [HttpPost]
        [Route("api/purchase/{itemName}", Name="GetItemByName")]
        public IHttpActionResult Post(string itemName)
        {
            // In case we need the request API key, we get it this way:
            // string apiKey = RequestContext.Principal.Identity.Name;

            var item = new PurchaseRequests(dataStore).PostHandler(itemName);
            if (item == null)
                return BadRequest("Invalid item name");
            else
                return CreatedAtRoute("GetItemByName", new { itemName = item.Name }, item);
        }
    }
}
