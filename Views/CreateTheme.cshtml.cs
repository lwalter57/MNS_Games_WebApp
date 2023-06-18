using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MNS_Games_WebApplication.Models;

namespace MNS_Games_WebApplication.Views
{
    public class CreateThemeModel : PageModel
    {
        private readonly MNS_Games_WebApplication.Models.MnsgamesContext _context;

        public CreateThemeModel(MNS_Games_WebApplication.Models.MnsgamesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Theme Theme { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Themes == null || Theme == null)
            {
                return Page();
            }

            _context.Themes.Add(Theme);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
