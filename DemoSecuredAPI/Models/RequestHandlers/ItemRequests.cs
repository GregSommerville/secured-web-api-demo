using DemoSecuredAPI.Models.DAL;
using System.Collections.Generic;

namespace DemoSecuredAPI.Models.RequestHandlers
{
    // this class handles all of the incoming requests relating to api/Items
    public class ItemRequests
    {
        private IItemRepository dataStore;

        // instantiated by passing in a repository from the controller
        public ItemRequests(IItemRepository repository)
        {
            dataStore = repository;
        }

        // GET api/Items
        public List<IItem> GetHandler()
        {
            var results = dataStore.GetInventory();
            return results;
        }
    }
}