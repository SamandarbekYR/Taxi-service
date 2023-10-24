using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.BokkingDidPpn
{
  public  class BookingDidPpnEntity: Auditable
    {
        public string PassengerPhoneNumber { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public bool IsAgree { get; set; } = false;
    }
}
