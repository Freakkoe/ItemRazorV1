using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class EditItemModel : PageModel
    {
        private ItemService _itemService;
        [BindProperty] 
        public Models.Item Item { get; set; }
        public EditItemModel(ItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _itemService.UpdateItem(Item);
            return RedirectToPage("GetAllItems");
        }

    }
}
