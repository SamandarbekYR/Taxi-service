using Car_service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.Cars
{
    public class Car : Auditable
    {
        [MaxLength(15)]
        public string Car_name { get; set; } = String.Empty;
        [MaxLength(8)]
        public string Number { get; set; } = String.Empty;
        [MaxLength(15)]
        public string Color { get; set; }  = String.Empty;
    
        [MaxLength(10)]
        public string Texpasport_seria { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Image_path { get; set; } = String.Empty;
    }
}
