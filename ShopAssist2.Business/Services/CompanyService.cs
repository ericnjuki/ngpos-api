using System;
using System.Collections.Generic;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.DataTransferObjects;
using AutoMapper;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Persistence;
using System.Linq;

namespace ShopAssist2.Business.Services {
    public class CompanyService : ICompanyService {
        private readonly ShopAssist2Context _ctx;
        private readonly IMapper _mapper;
        public CompanyService(IMapper mapper, ShopAssist2Context ctx) {
            _ctx = ctx;
            _mapper = mapper;
        }
        public IEnumerable<CompanyDto> GetAll() {
            return _ctx.Companies.Select(c => _mapper.Map<CompanyDto>(c));
        }

        public CompanyDto GetByCompanyId(int companyId) {
            var company = _ctx.Companies.Find(companyId);
            return company == null ? null : _mapper.Map<CompanyDto>(company);
        }

        public void AddCompany(CompanyDto company) {
            if(company == null) {
                throw new ArgumentNullException(nameof(company));
            }
            _ctx.Companies.Add(_mapper.Map<Company>(company));
            _ctx.SaveChanges();
        }
    }
}