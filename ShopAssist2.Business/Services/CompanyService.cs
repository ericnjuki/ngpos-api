using System.Collections.Generic;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssist2.Business.Services
{
    public class CompanyService : ICompanyService
    {
        public IEnumerable<CompanyDto> GetAll()
        {
            return new List<CompanyDto>();
        }

        public CompanyDto GetByCompanyId(int companyId)
        {
            return new CompanyDto();
        }

        public void AddCompany(CompanyDto company)
        {
        }
    }
}