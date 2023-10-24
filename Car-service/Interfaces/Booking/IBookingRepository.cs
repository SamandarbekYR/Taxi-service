using Car_service.Entities.Booking;
using Car_service.ViewModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.Booking
{
    public interface IBookingRepository:IRepository<booking,BookingViewModel>
    {
        public Task<BookingViewModel> GetList(string DriverName);
    }
}
