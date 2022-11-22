using ItemRazorV1.Models;

namespace ItemRazorV1.MockData
{
    public class MockItems
    {
        private static List<Item> _items = new List<Item>() 
        {
            new Item(1, "PC", 5999),
            new Item(2, "Skærm", 1999),
            new Item(3, "Tastatur", 999),
            new Item(4, "Mus", 349),
            new Item(5, "TV", 4999),
            new Item(6, "Mussemåtte", 149)
        };
        public static List<Item> GetMockItems()
        {
            return _items;
        }

    }
}
