using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.UserService.Models
{
    public class UserAddress
    {
        //[ForeignKey("UserId")]
        [Key]
        public int AddressId { get; set; }
        public string DoorNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Locality { get; set; }
        public string District { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
