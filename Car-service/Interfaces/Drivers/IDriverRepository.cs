using Car_service.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.Drivers;

public interface IDriverRepository:IRepository<DriverEntitiy,DriverEntitiy>
{
    public Task<int> CountAsync();
    public Task<List<DriverEntitiy>> GetAll();
    public Task<List<DriverEntitiy>> GetAsync(int id);
   public Task<int> UpdateBooked(string PhoneNumber, DriverEntitiy editObj, int number);
    public Task<int> GetPersonNum(string PhoneNumber);
    public Task<int>UpdateBookedMinus(string PhoneNumber,DriverEntitiy editObj, int number);
    public Task<int> UpdateBookedZero(int id, DriverEntitiy editObj);
}
