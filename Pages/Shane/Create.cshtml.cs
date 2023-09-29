using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JellyPages.Data;
using JellyPages.Models;

namespace JellyPages.Pages.Shane
{
    public class CreateModel : PageModel
    {
        private readonly JellyPages.Data.JellyPagesContext _context;

        public CreateModel(JellyPages.Data.JellyPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Phonebook Phonebook { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Phonebook == null || Phonebook == null)
            {
                return Page();
            }

            _context.Phonebook.Add(Phonebook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
