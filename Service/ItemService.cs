using ItemRazorV1.MockData;
using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{

    public class ItemService : IItemService
    {
        private List<Item> _items;

        public ItemService()
        {
            _items = MockItems.GetMockItems();
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in _items)
            {
                if (item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }
        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Item> filterList = new List<Item>();
            foreach (Item item in _items)
            {
                if ((minPrice == 0 && item.Price <= maxPrice) || (maxPrice == 0 && item.Price >= minPrice) || (item.Price >= minPrice && item.Price <= maxPrice))
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }
        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                foreach (Item i in _items)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                        i.Price = item.Price;
                    }
                }
            }
        }
        public Item GetItem(int id)
        {
            foreach (var item in _items)
            {
                if(item.Id == id) { return item; }
            }
            return null;

        }

        IEnumerable<Item> IItemService.UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
        public Item DeleteItem(int? itemId)
        {
            foreach (Item item in _items)
            {
                if (item.Id == itemId)
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public Item DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
