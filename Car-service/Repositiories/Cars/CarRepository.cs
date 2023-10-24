using Car_service.Constants;
using Car_service.Entities.Cars;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.Cars;
using Car_service.Unitils;
using Car_service.Windows.Driver;
using Microsoft.AspNet.SignalR.Hubs;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Car_service.Repositiories.Cars
{


    public class CarRepository : ICarRepository
    {
        private readonly NpgsqlConnection _connection;
        public CarRepository()
        {
            _connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING);

        }



        public async Task<int> CretaAsync(Car obj)
        {
            try
            {
                await _connection.OpenAsync();

                int result = 0;
                string query = "INSERT INTO public.\"Car\"( car_name, number, color, texpasport_seria, description, image_path, created_at, updated_at) VALUES (@car_name, @number, @color, @texpasport_seria, @description, @image_path, @created_at, @updated_at);";


                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("image_path", obj.Image_path);
                    command.Parameters.AddWithValue("car_name", obj.Car_name);
                    command.Parameters.AddWithValue("number", obj.Number);
                    command.Parameters.AddWithValue("color", obj.Color);
                    command.Parameters.AddWithValue("texpasport_seria", obj.Texpasport_seria);
                    command.Parameters.AddWithValue("description", obj.Description);
                    command.Parameters.AddWithValue("car_name", obj.Car_name);
                    command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                    command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);
                    result = await command.ExecuteNonQueryAsync();
                }
                return result;

            }

            catch
            {
                return 0;
            }

            finally { await _connection.CloseAsync(); }
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Car>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Car>> GetAsync(string city)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Car>> GetAsync(int id)
        {

            try
            {
                await _connection.OpenAsync();
                List<Car> list = new List<Car>();
                string query = $"SELECT * FROM public.\"Car\" where id = {int.Parse(DriverLogin.textId.Text)}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Car car = new Car();

                            car.Id = reader.GetInt32(0);
                            car.Car_name = reader.GetString(1);
                            car.Number = reader.GetString(2);
                            car.Color = reader.GetString(3);
                            car.Texpasport_seria = reader.GetString(4);
                            car.Description = reader.GetString(5);
                            car.Image_path = reader.GetString(6);
                            car.CreatedAt = reader.GetDateTime(7);
                            car.UpdatedAt = reader.GetDateTime(8);

                            list.Add(car);


                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Car>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<List<Car>> GetImagePath(string imagePath)
        {
            try
            {
                await _connection.OpenAsync();
                List<Car> list = new List<Car>();
                string query = $"SELECT * FROM public.\"Car\" where image_path = '{imagePath}'";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Car car = new Car();

                            car.Id = reader.GetInt32(0);
                            car.Car_name = reader.GetString(1);
                            car.Number = reader.GetString(2);
                            car.Color = reader.GetString(3);
                            car.Texpasport_seria = reader.GetString(4);
                            car.Description = reader.GetString(5);
                            car.Image_path = reader.GetString(6);
                            car.CreatedAt = reader.GetDateTime(7);
                            car.UpdatedAt = reader.GetDateTime(8);

                            list.Add(car);


                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Car>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public Task<List<Car>> Grid(int id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<int> UpdateAsync(long id, Car editObj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Car\" Set " +
                               $"car_name =@car_name, color =@color, " +
                               $"texpasport_seria =@texpasport_seria, " +
                               $"description =@description, image_path =@image_path " +
                               $"WHERE id = {id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("image_path", editObj.Image_path);
                    command.Parameters.AddWithValue("car_name", editObj.Car_name);
                    command.Parameters.AddWithValue("color", editObj.Color);
                    command.Parameters.AddWithValue("texpasport_seria", editObj.Texpasport_seria);
                    command.Parameters.AddWithValue("description", editObj.Description);
                    var dbrresult = await command.ExecuteNonQueryAsync();
                    return dbrresult;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
