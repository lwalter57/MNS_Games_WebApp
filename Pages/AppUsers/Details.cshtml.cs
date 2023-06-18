using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MNS_Games_WebApplication.Models;

namespace MNS_Games_WebApplication.Pages.AppUsers
{
    public class DetailsModel : PageModel
    {
        private readonly MNS_Games_WebApplication.Models.MnsgamesContext _context;

        public DetailsModel(MNS_Games_WebApplication.Models.MnsgamesContext context)
        {
            _context = context;
        }

      public AppUser AppUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppUsers == null)
            {
                return NotFound();
            }

            var appuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (appuser == null)
            {
                return NotFound();
            }
            else 
            {
                AppUser = appuser;
            }
            return Page();
        }
    }
}
