using Car_service.Entities;
using Car_service.ViewModels.RatingViewModel;
using Car_service.Windows.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.Machines
{
    public interface IMachineRepository : IRepository<DriverCar1,Rating>
    {
        Task<List<Rating>> GetAll();
    }
}
