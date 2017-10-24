using System.Collections.Generic;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssist2.Business.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAll();

        CompanyDto GetByCompanyId(int companyId);

        void AddCompany(CompanyDto company);
    }
}