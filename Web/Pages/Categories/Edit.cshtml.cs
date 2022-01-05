using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;

namespace Web.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            Category = await _context.Categories.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = await _context.Categories.FindAsync(Category.Id);
                categoryFromDb.Name = Category.Name;
                categoryFromDb.CreationDate = Category.CreationDate;
                                
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
