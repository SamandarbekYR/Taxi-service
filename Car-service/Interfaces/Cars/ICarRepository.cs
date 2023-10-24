using Car_service.Entities.Cars;
using Car_service.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Car_service.Interfaces.Cars
{
 public interface ICarRepository:IRepository<Car,Car>
    {
        public Task<List<Car>> Grid(int id);
        public Task<List<Car>> GetAsync(int id);
        public Task<List<Car>> GetImagePath(string  imagePath);
    }
}
