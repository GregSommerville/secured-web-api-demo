using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoSecuredAPI.Models.DAL
{
    public class ItemRepository : IItemRepository
    {
        // Normally this item repository would be a class that communicates with a database.
        // For this simple demo, we simply use an in-memory list of items

        private List<IItem> items = new List<IItem>();

        public ItemRepository()
        {
            // populate with some sample data
            items.Add(new Item("Hamburger", "A lovely medium rare burger", 9));
            items.Add(new Item("Cheeseburger", "A lovely medium rare burger with melted Cheddar", 10));
            items.Add(new Item("Fries", "Crispy, tender french fries", 3));
            items.Add(new Item("SweetFries", "Delicious sweet potato fries", 4));
            items.Add(new Item("DietCoke", "The old favorite", 2));
            items.Add(new Item("Ale", "House Ale", 4));
            items.Add(new Item("Porter", "House Porter", 4));
            items.Add(new Item("Stout", "House Stout", 4));
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
        }

        public List<IItem> GetInventory()
        {
            return items;
        }
    }
}