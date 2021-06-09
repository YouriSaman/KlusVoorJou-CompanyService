using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.DAL
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
            
        }
    }
}
