using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Models;

namespace CompanyService.DAL
{
    public class CompanyDAL
    {
        private readonly CompanyDbContext _dbContext;

        public CompanyDAL(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCompany(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}
