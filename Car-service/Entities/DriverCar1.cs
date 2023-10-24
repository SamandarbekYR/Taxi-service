using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities
{
    public class DriverCar1 : Auditable
    {
        public int DriverId { get; set; }
        public int CarId { get; set; }

    }
}
