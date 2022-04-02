using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.UserService.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
       
        [StringLength(100)]
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Role { get; set; }
        [Timestamp]
        public Byte[] UserCreatedAt { get; set; }

    }
}
