using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace DemoSecuredAPI.Models.DAL
{
    // alias for ease of typing
    using ItemCollection = List<IItem>;

    public class ItemRepository : IItemRepository
    {
        // Normally this item repository would be a class that communicates with a database.
        // For this simple demo, we simply use an in-memory list of items

        private ItemCollection items = new ItemCollection();
        private const string cacheName = "itemCache";

        public ItemRepository()
        {
            if (TryLoadFromCache() == false)
            {
                // no cached data, so use sample
                LoadSampleInventory();
                SaveToCache();
            }
        }

        private void LoadSampleInventory()
        {
            items.Add(new Item("Hamburger", "A lovely medium rare burger", 9));
            items.Add(new Item("Cheeseburger", "A lovely medium rare burger with melted Cheddar", 10));
            items.Add(new Item("Fries", "Crispy, tender french fries", 3));
            items.Add(new Item("SweetFries", "Delicious sweet potato fries", 4));
            items.Add(new Item("DietCoke", "The old favorite", 2));
            items.Add(new Item("Ale", "House Ale", 4));
            items.Add(new Item("Porter", "House Porter", 4));
            items.Add(new Item("Stout", "House Stout", 4));
        }

        private bool TryLoadFromCache()
        {
            // return false if no cache avail, otherwise load
            var cache = MemoryCache.Default;
            if (cache.Contains(cacheName) == false) return false;

            items = cache[cacheName] as ItemCollection;
            return true;
        }

        private void SaveToCache()
        {
            var cache = MemoryCache.Default;
            cache[cacheName] = items;
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