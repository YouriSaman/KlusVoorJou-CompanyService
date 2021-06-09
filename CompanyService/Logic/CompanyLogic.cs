using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.DAL;
using CompanyService.Models;

namespace CompanyService.Logic
{
    public class CompanyLogic
    {
        private readonly CompanyDAL _companyDal;

        public CompanyLogic(CompanyDbContext dbContext)
        {
            _companyDal = new CompanyDAL(dbContext);
        }

        public async Task AddCompany(Company company)
        {
            await _companyDal.AddCompany(company);
        }
    }
}
