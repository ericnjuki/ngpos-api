using System;
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
            return _ctx.StockItems.ToList()
                .Where(i => i.Deleted == 0)
                .Select(i => _mapper.Map<ItemDto>(i));
            //return _ctx.StockItems.ToList().Select(i => _mapper.Map<ItemDto>(i));
        }
        public ItemDto GetItemById(int itemId) {
            var item = _ctx.Transactions.Find(itemId);
            return item == null ? null : _mapper.Map<ItemDto>(item);
        }

        // consider removing this
        public void AddItem(ItemDto item) {
            var itemToAdd = _mapper.Map<Item>(item);
            itemToAdd.Deleted = 0;
            itemToAdd.DeleteDate = null;

            _ctx.StockItems.Add(itemToAdd);
            _ctx.SaveChanges();
        }

        public void AddItems(ICollection<ItemDto> items) {
            foreach(var itemDto in items) {
                AddItem(itemDto);
            }
        }

        public void UpdateItems(ICollection<ItemDto> items) {
            foreach(var item in items) {
                var itemEntity = _mapper.Map<Item>(item);
                _ctx.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
            }
            _ctx.SaveChanges();
        }

        public IEnumerable<ItemDto> DeleteItems(ICollection<int> itemIds) {
            List<Item> items = _ctx.StockItems.Where(i => itemIds.Contains(i.ItemId)).ToList();
            //_ctx.StockItems.RemoveRange(items);
            for(var i = 0; i < items.Count; i++) {
                var deletedItem = items.ToArray()[i];
                deletedItem.Deleted = 1;
                deletedItem.DeleteDate = DateTime.Now;
                _ctx.Entry(deletedItem).State = System.Data.Entity.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return GetAll();
        }
    }
}
