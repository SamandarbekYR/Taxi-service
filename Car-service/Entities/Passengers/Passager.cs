using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.Passengers
{
    public class Passager :Human
    {
        public bool Is_male { get; set; }
        public int  thereArePassengers { get; set; }
        public string timeToLeave { get; set; } = String.Empty;
        public string place { get; set; } = String.Empty;
        public string place1 { get; set; } = String.Empty;
        public bool IsAktiv { get; set; } = true;
    }
}
