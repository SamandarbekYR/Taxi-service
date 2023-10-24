using Car_service.Constants;
using Car_service.Entities;
using Car_service.Interfaces.Machines;
using Car_service.Unitils;
using Car_service.ViewModels.RatingViewModel;
using Microsoft.Owin.Security;
using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories.Machinnes
{



    public class MachineRepository : BaseRepository, IMachineRepository
    {
        public Task<int> CretaAsync(DriverCar1 obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<Rating>> GetAll()
        {
            try
            {
                await _connection.OpenAsync();
                List<Rating> list = new List<Rating>();
                string query = $"select * from rating_view order by rating desc";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Rating rating = new Rating();
                            rating.Id = reader.GetInt32(0);
                            rating.degree = reader.GetInt32(1);
                            rating.Name= reader.GetString(2);
                            rating.PhoneNumber = reader.GetString(3);
                            rating.city= reader.GetString(4);
                            rating.CarName= reader.GetString(5);
                            rating.CarImage= reader.GetString(6);
                           
                            list.Add(rating);


                        }
                    }

                }
                return list;
            }
            catch { return await List<Rating>(); }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        private Task<List<T>> List<T>()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Rating>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, DriverCar1 editObj)
        {
            throw new NotImplementedException();
        }

    }
}
