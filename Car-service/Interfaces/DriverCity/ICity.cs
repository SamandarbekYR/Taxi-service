using Car_service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.DriverCity
{
    internal interface ICity:IRepository<City,City>
    {
        public Task<List<City>> GetAll();
    }
}
