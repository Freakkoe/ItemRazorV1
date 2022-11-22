using ItemRazorV1.MockData;
using ItemRazorV1.Models;
using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        private ItemService _itemService;

        public GetAllItemsModel(ItemService itemService)
        {
            _itemService = itemService;
        }

        public List<Models.Item> Items { get; private set; }


        public void OnGet()
        {
            Items = _itemService.GetItems(); ;


        }
        [BindProperty] public string SearchString { get; set; }

        public IActionResult OnPostNameSearch()
        {
            Items = _itemService.NameSearch(SearchString).ToList();
            return Page();
        }

        [BindProperty] public int MinPrice { get; set; }
        [BindProperty] public int MaxPrice { get; set; }

        public IActionResult OnPostPriceFilter()
        {
            Items = _itemService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }





    }
}
