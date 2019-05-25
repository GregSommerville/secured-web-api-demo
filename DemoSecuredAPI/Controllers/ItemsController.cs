﻿using DemoSecuredAPI.Models.DAL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoSecuredAPI.Controllers
{
    [AllowAnonymous]
    public class ItemsController : ApiController
    {
        // allow dependency injection (via constructor) to pass in data store
        private IItemRepository dataStore = new ItemRepository();

        public ItemsController() {}
        public ItemsController(IItemRepository repository)
        {
            dataStore = repository;
        }

        // GET api/items 
        [ResponseType(typeof(List<IItem>))]
        public IHttpActionResult Get()
        {
            // returns a list of all of the unsold items 
            var results = dataStore.GetInventory();
            return Ok(results);
        }
    }
}
