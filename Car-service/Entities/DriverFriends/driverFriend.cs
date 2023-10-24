using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.DriverFriends
{
    public class driverFriend:BaseEntity
    {

        public string Name { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public bool IsToshkent { get; set; }
        public string City { get; set; } = String.Empty;
        public int Score { get; set; }
        public int DriverId { get; set; }
    }
}
