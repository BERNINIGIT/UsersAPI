namespace UsersAPI.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public decimal UsdBalance { get; set; }
    }
}
