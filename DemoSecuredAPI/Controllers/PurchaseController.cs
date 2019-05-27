﻿using DemoSecuredAPI.Models.DAL;
using System.Web.Http;
using System.Web.Http.Description;

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
        //[ResponseType(typeof(IItem))]
        [Authorize]
        [HttpPost]
        [Route("api/purchase/{itemName}", Name="GetItemByName")]
        public IHttpActionResult Post(string itemName)
        {
            // in case we need the request API key, we get it this way:
            // string apiKey = RequestContext.Principal.Identity.Name;

            var item = dataStore.Buy(itemName);
            if (item == null)
                return BadRequest("Invalid item name");
            else
                return CreatedAtRoute("GetItemByName", new { itemName = item.Name }, item);
        }
    }
}
