namespace ShopAssist2.Common.DataTransferObjects
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}