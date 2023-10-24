using Car_service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.ViewModels.RatingViewModel
{
    public class Rating:BaseEntity
    {
        public int degree { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string CarImage { get; set; } = String.Empty;
        public string CarName { get; set; } = string.Empty;

 
    }
}
