using DemoSecuredAPI.Models.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DemoSecuredAPI.Tests
{
    // alias for ease of typing
    using ItemCollection = List<IItem>;

    class MockItemRepository : IItemRepository
    {
        // Normally this item repository would be a class that communicates with a database.
        // For this simple demo, we simply use an in-memory list of items
        private ItemCollection items = new ItemCollection();

        public MockItemRepository()
        {
            items.Add(new Item("ChickenSoup", "Grandma's chicken soup", 3));
            items.Add(new Item("Caeser", "Fresh Caeser Salad", 6));
            items.Add(new Item("TunaMelt", "Tuna melt on rye", 5));
            items.Add(new Item("SweetFries", "Delicious sweet potato fries", 4));
        }

        public IItem Buy(string itemName)
        {
            // try to find it
            var item = items.FirstOrDefault(i => i.Name == itemName);

            // if found, remove from inventory
            if (item != null)
                items.Remove(item);

            return item;
        }

        public void Dispose()
        {
            items.Clear();
        }

        public List<IItem> GetInventory()
        {
            return items;
        }
    }
}
