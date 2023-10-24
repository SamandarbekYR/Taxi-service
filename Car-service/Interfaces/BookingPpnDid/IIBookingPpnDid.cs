using Car_service.Entities.BokkingDidPpn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.BookingPpnDid
{
     public interface  IIBookingPpnDid:IRepository<BookingDidPpnEntity,BookingDidPpnEntity>
    {
        public Task<List<int>> GetDriverId(string PassengerPhoneNumber);
        public Task<List<BookingDidPpnEntity>> GetBookingDiagnosis(string PassengerPhoneNumber, int DriverId);
        public Task<int> DeletPhoneNumberDriverId(string PassengerPhoneNumber, int DriverId);
       
        public Task<int> UpdateIsAgree(string phoneNumber, BookingDidPpnEntity editObj);
        public Task<bool> GetIsAgree(string phoneNumber);
        //public Task<int> GetDriverId()
    }
}
