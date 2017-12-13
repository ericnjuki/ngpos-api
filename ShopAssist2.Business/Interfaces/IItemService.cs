using System.Collections.Generic;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssist2.Business.Interfaces {
    public interface IItemService {
        IEnumerable<ItemDto> GetAll();

        ItemDto GetItemById(int itemId);

        void AddItem(ItemDto item);

        void AddItems(ICollection<ItemDto> items);

        void UpdateItems(ICollection<ItemDto> items);

        IEnumerable<ItemDto> DeleteItems(ICollection<int> items);
    }
}
