using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Persistence;
using ShopAssist2.Business.Interfaces;

namespace ShopAssist2.Business.Services {
    public class ItemService : IItemService {
        private readonly ShopAssist2Context _ctx;
        private readonly IMapper _mapper;
        public ItemService(ShopAssist2Context shopAssist2Context, IMapper mapper) {
            _ctx = shopAssist2Context;
            _mapper = mapper;
        }

        public IEnumerable<ItemDto> GetAll() {
            return _ctx.StockItems.ToList().Select(i => _mapper.Map<ItemDto>(i));
        }
        public ItemDto GetItemById(int itemId) {
            var item = _ctx.Transactions.Find(itemId);
            return item == null ? null : _mapper.Map<ItemDto>(item);
        }

        public void AddItem(ItemDto item) {
            _ctx.StockItems.Add(_mapper.Map<Item>(item));
            _ctx.SaveChanges();
        }

        public void AddManyItems(ICollection<ItemDto> items) {
            foreach(var itemDto in items) {
                _ctx.StockItems.Add(_mapper.Map<Item>(itemDto));
            }
            _ctx.SaveChanges();
        }

        public void UpdatItem(ItemDto item) {
            var itemEntity = _mapper.Map<Item>(item);
            _ctx.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
