﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JellyPages.Data;
using JellyPages.Models;

namespace JellyPages.Pages.Shane
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

        public async Task OnGetAsync() {
            Phonebook = await _context.Phonebook.ToListAsync();
        }
    }
}

