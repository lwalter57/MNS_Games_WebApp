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
    public class IndexModel : PageModel
    {
        private readonly MNS_Games_WebApplication.Models.MnsgamesContext _context;

        public IndexModel(MNS_Games_WebApplication.Models.MnsgamesContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AppUsers != null)
            {
                AppUser = await _context.AppUsers.ToListAsync();
            }
        }
    }
}
