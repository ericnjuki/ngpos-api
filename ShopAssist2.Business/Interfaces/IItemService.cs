using System.Collections.Generic;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssist2.Business.Interfaces {
    public interface IItemService {
        IEnumerable<ItemDto> GetAll();

        ItemDto GetItemById(int itemId);

        void AddItem(ItemDto item);

        void AddManyItems(ICollection<ItemDto> items);

        void UpdatItem(ItemDto item);
    }
}
