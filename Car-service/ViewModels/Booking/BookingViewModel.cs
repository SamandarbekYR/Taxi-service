using Car_service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.ViewModels.Booking
{
    public class BookingViewModel: Auditable
    {
        public string DriverName { get; set; } = String.Empty;
        public string PassengerInformation { get; set; } = String.Empty;
        public string StartPlace { get; set; } = String.Empty;
        public string EndPlace { get; set; } = String.Empty;






    }
}
