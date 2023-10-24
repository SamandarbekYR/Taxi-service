using Car_service.Constants;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.DriverCity;
using Car_service.Unitils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories.Drivercity
{

    public class CityRepository : BaseRepository, ICity
    {
        public Task<int> CretaAsync(City obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<City>> GetAll()
        {
            try
            {
                await _connection.OpenAsync();
                List<City> list = new List<City>();
                string query = $"select city from \"City\" ";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            City city   = new City();
                             city.cities = reader.GetString(0);
                            

                            list.Add(city);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<City>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public Task<IList<City>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, City editObj)
        {
            throw new NotImplementedException();
        }
    }
}
