using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;

namespace ShopAssist2 {
    public class AutoMapperConfig {
        public static IMapper GetMapper() {
            var config = new MapperConfiguration( cfg => {
                cfg.CreateMap<Company, CompanyDto>().ReverseMap();
                cfg.CreateMap<User, UserDto>().ReverseMap();
            } );

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}