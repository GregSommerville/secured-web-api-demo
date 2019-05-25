namespace DemoSecuredAPI.Models.DAL
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get ; set ; }
        public int Price { get ; set ; }

        public Item(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void Dispose()
        {
        }

    }
}