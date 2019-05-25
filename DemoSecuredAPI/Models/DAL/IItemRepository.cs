using System;
using System.Collections.Generic;

namespace DemoSecuredAPI.Models.DAL
{
    public interface IItemRepository : IDisposable
    {
        List<IItem> GetInventory();
        IItem Buy(string itemName);
    }

    public interface IItem : IDisposable
    {
        string Name { get; set; }
        string Description { get; set; }
        int Price { get; set; }
    }
}
