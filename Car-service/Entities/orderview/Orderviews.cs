using Car_service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.orderview
{
    public class Orderviews
    {
        public int BookingId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Score { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int Booked { get; set; }
        public string place1 { get; set; } = string.Empty;
        public bool IsToshket { get; set; }
        public int DriverId { get; set; }
        public string PassengerPhoneNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsAgree { get; set; }
        public int ThereArePassengers { get; set; } 
        public string TimeToLeave { get; set; } =String.Empty;
        public bool IsMale { get; set; } 
        public string PassengerName { get; set; } = String.Empty;
        public string wherefrom { get; set; } = String.Empty;
        public string Whereto { get; set; } = String.Empty;
    }
}
