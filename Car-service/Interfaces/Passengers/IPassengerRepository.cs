using Car_service.Entities.Passengers;
using Car_service.Unitils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.Passengers
{
  public   interface IPassengerRepository:IRepository<Passager,Passager>

    {
        public Task<List<Passager>> GetAllTrue();
        public Task<int> UpdateAktiv(string PhoneNumber, Passager editObj);
        public Task<int> GetPersonNum(string PhoneNumber);
       


    }
}
