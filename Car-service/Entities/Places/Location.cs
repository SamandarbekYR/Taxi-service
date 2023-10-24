using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.Places
{
    public class Location:Auditable
    {
        public string City { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
    }
}
