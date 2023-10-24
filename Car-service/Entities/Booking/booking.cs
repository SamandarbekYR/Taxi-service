using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities.Booking
{
    public class booking:BaseEntity
    {
        public long StartPositionId  { get; set; }
        public long EndPositionId { get; set; }

        public long DriverId { get; set;}
        public long PassengerId { get; set;}
        public TimeOnly StartAt { get; set; }
        public TimeOnly EndAt { get; set;}


    }
}
