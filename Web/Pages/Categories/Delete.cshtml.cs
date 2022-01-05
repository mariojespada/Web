using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;

namespace Web.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var categoryFromDb = await _context.Categories.FindAsync(Category.Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryFromDb);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
