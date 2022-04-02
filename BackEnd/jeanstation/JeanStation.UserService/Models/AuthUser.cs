namespace JeanStation.UserService.Models
{
    public class AuthUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

    }
}
