using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JellyPages.Data;
using JellyPages.Models;

namespace JellyPages.Pages.Nicole
{
    public class IndexModel : PageModel
    {
        private readonly JellyPages.Data.JellyPagesContext _context;

        public IndexModel(JellyPages.Data.JellyPagesContext context)
        {
            _context = context;
        }

        public IList<Phonebook> Phonebook { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string NameSort { get; set; }
        public string FirstSort { get; set; }
        public string LastSort { get; set; }

        public async Task OnGetAsync(string sortOrder) {
            FirstSort = String.IsNullOrEmpty(sortOrder) ? "FirstDesc" : "";
            LastSort = sortOrder == "LastAsc" ? "LastDesc" : "LastAsc";

            var phonebook = from r in _context.Phonebook
                            select r;

            if (!string.IsNullOrEmpty(SearchString)) {
                phonebook = phonebook.Where(r => r.FirstName.Contains(SearchString)
                            || r.LastName.Contains(SearchString));
            }
            switch (sortOrder) {
                case "FirstDesc":
                    phonebook = phonebook.OrderByDescending(r => r.FirstName);
                    break;
                case "LastDesc":
                    phonebook = phonebook.OrderByDescending(r => r.LastName);
                    break;
                case "LastAsc":
                    phonebook = phonebook.OrderBy(r => r.LastName);
                    break;

                default:
                    phonebook = phonebook.OrderBy(r => r.FirstName);
                    break;
            }

            Phonebook = await phonebook.ToListAsync();
        }
    }
}