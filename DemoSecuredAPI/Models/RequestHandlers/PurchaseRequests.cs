using DemoSecuredAPI.Models.DAL;

namespace DemoSecuredAPI.Models.RequestHandlers
{
    // this class handles all of the incoming requests relating to api/Purchase
    public class PurchaseRequests
    {
        private IItemRepository dataStore;

        // instantiated by passing in a repository from the controller
        public PurchaseRequests(IItemRepository repository)
        {
            dataStore = repository;
        }

        // POST api/Purchase
        public IItem PostHandler(string itemName)
        {
            return dataStore.Buy(itemName);
        }
    }
}