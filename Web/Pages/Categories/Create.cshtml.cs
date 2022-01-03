using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;

namespace Web.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _context.Categories.AddAsync(Category);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
