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
    public class IndexModel : PageModel
    {
        private readonly JellyPages.Data.JellyPagesContext _context;

        public IndexModel(JellyPages.Data.JellyPagesContext context)
        {
            _context = context;
        }

        public IList<Phonebook> Phonebook { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }            //Search Bar
        public string FirstNameSort { get; set; }          //Column Sorting
        public string LastNameSort { get; set; }
        public string AddressSort { get; set; }
        public string PhoneSort { get; set; }
        public string EmailSort { get; set; }

        public async Task OnGetAsync(string sortOrder) {
            FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "FirstDesc" : "";
            LastNameSort = sortOrder == "LastAsc" ? "LastDesc" : "LastAsc";
            AddressSort = sortOrder == "AddressAsc" ? "AddressDesc" : "AddressAsc";
            PhoneSort = sortOrder == "PhoneAsc" ? "PhoneDesc" : "PhoneAsc";
            EmailSort = sortOrder == "EmailAsc" ? "EmailDesc" : "EmailAsc";

            var phonebook = from f in _context.Phonebook
                            select f;
            if (!string.IsNullOrEmpty(SearchString)) {
                phonebook = phonebook.Where(f => f.FirstName.Contains(SearchString)
                               || f.LastName.Contains(SearchString)
                               || f.Address.Contains(SearchString)
                               || f.Phone.Contains(SearchString)
                               || f.Email.Contains(SearchString));
            }
            switch (sortOrder) {
                case "FirstDesc":
                    phonebook = phonebook.OrderByDescending(f => f.FirstName);
                    break;
                case "LastDesc":
                    phonebook = phonebook.OrderByDescending(f => f.LastName);
                    break;
                case "LastAsc":
                    phonebook = phonebook.OrderBy(f => f.LastName);
                    break;
                case "AddresssDesc":
                    phonebook = phonebook.OrderByDescending(f => f.Address);
                    break;
                case "AddressAsc":
                    phonebook = phonebook.OrderBy(f => f.Address);
                    break;
                case "PhoneDesc":
                    phonebook = phonebook.OrderByDescending(f => f.Phone);
                    break;
                case "PhoneAsc":
                    phonebook = phonebook.OrderBy(f => f.Phone);
                    break;
                case "EmailDesc":
                    phonebook = phonebook.OrderByDescending(f => f.Email);
                    break;
                case "EmailAsc":
                    phonebook = phonebook.OrderBy(f => f.Email);
                    break;
                default:
                    phonebook = phonebook.OrderBy(f => f.FirstName);
                    break;

            }

            Phonebook = await phonebook.ToListAsync();

        }
    }
}
