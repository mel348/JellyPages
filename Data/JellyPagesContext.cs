using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JellyPages.Models;

namespace JellyPages.Data
{
    public class JellyPagesContext : DbContext
    {
        public JellyPagesContext (DbContextOptions<JellyPagesContext> options)
            : base(options)
        {
        }

        public DbSet<JellyPages.Models.Phonebook> Phonebook { get; set; } = default!;
    }
}
