using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeanStation.OrderService.Models
{
    public class UserAddress
    {
        
        public int AddressId { get; set; }
        public string DoorNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Locality { get; set; }
        public string District { get; set; }
        public int? UserId { get; set; }


    }
}
