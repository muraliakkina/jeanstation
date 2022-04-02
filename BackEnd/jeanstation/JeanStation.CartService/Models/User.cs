using System;


namespace JeanStation.CartService.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
       
      
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Role { get; set; }
        
        public Byte[] UserCreatedAt { get; set; }

    }
}
