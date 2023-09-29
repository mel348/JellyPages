using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JellyPages.Data;
using JellyPages.Models;

namespace JellyPages.Pages.Mel
{
    public class DetailsModel : PageModel
    {
        private readonly JellyPages.Data.JellyPagesContext _context;

        public DetailsModel(JellyPages.Data.JellyPagesContext context)
        {
            _context = context;
        }

      public Phonebook Phonebook { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Phonebook == null)
            {
                return NotFound();
            }

            var phonebook = await _context.Phonebook.FirstOrDefaultAsync(m => m.ID == id);
            if (phonebook == null)
            {
                return NotFound();
            }
            else 
            {
                Phonebook = phonebook;
            }
            return Page();
        }
    }
}
