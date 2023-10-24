using Car_service.Enums;
using Car_service.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.Drivers

{
    public class DriverEntitiy : Human
    {

        public int Rating { get; set; } 
        public string ImagePath { get; set; } = String.Empty;
        [MaxLength(9)]
        public string Prava { get; set; } = String.Empty;
        [MaxLength(20)]
        public int Booked { get; set; } 
        public string City1 { get; set; } = String.Empty;
        [MaxLength(20)]
        public DateTime working { get; set; }
        [MaxLength(15)]
        public string Login { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public DriverEntitiy() => working = TimeHelper.GetDateTime();
        public bool IsToshkent { get; set; }

    }
}