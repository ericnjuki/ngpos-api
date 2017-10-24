using System.Collections.Generic;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssist2.Business.Interfaces
{
    public interface IUserService
    {
        //IEnumerable<UserDto> GetAll();

        //UserDto GetByUserId(int userId);

        void AddUser(UserDto user);

        //void UpdateUser(UserDto user);
    }
}