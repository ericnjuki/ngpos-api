using AutoMapper;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;

namespace ShopAssist2 {
    public class AutoMapperConfig {
        public static IMapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Company, CompanyDto>().ReverseMap();
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Transaction, TransactionDto>().ReverseMap();
                cfg.CreateMap<Item, ItemDto>().ReverseMap();
                cfg.CreateMap<TransactionItem, TransactionItemDto>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}