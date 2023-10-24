using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities
{
    public class Human:Auditable
    {
        [MaxLength(15)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(13)]
        public string Phone_number { get; set; } = String.Empty;

    }
}
