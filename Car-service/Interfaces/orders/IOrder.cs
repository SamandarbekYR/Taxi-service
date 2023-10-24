using Car_service.Entities.orderview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.orders
{
   public interface IOrder:IRepository<Orderviews,Orderviews>
    {
        public Task<List<Orderviews>> Search(string phoneNumber);
        public Task<List<Orderviews>> SearchPassengerAgree(int id);
        public Task<List<Orderviews>> SearchDriverInfo(string phoneNumber);
        
    }
}
