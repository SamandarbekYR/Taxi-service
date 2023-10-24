using Car_service.Constants;
using Car_service.Entities.DriverFriends;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.Passengers;
using Car_service.Pages;
using Car_service.Unitils;
using Car_service.Windows.Driver;
using Npgsql;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Car_service.Repositiories.Drivers
{

    public class PassengerRepository : IPassengerRepository
    {
        private readonly NpgsqlConnection _connection;

        public PassengerRepository()
        {
            _connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING);
        }
        public async Task<int> CretaAsync(Passager obj)
        {
            try
            {
                await _connection.OpenAsync();

                int result = 0;
                string query = "INSERT INTO public.\"Passenger\"( name, phone_number, there_are_passengers, time_to_leave, is_male, created_at, updated_at, place, place1, is_aktiv) VALUES(@name, @phone_number, @there_are_passengers, @time_to_leave, @is_male, @created_at, @updated_at, @place, @place1, @is_aktiv);";


                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("id", obj.Id);
                    command.Parameters.AddWithValue("name", obj.Name);
                    command.Parameters.AddWithValue("phone_number", obj.Phone_number);
                    command.Parameters.AddWithValue("there_are_passengers", obj.thereArePassengers);
                    command.Parameters.AddWithValue("time_to_leave", obj.timeToLeave);
                    command.Parameters.AddWithValue("is_male", obj.Is_male);
                    command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                    command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);
                    command.Parameters.AddWithValue("place", obj.place);
                    command.Parameters.AddWithValue("place1", obj.place1);
                    command.Parameters.AddWithValue("is_aktiv", obj.IsAktiv);
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

      



        public async Task<IList<Passager>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                List<Passager> list = new List<Passager>();
                string query = $"SELECT * FROM public.\"Passenger\" order by id offset " +
                    $"{(@params.PageNumber - 1) * @params.PageSize}" +
                    $" limit {@params.PageSize}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Passager passager = new Passager();
                            passager.Id = reader.GetInt32(0);
                            passager.Name = reader.GetString(1);
                            passager.Phone_number = reader.GetString(2);
                            passager.thereArePassengers = reader.GetInt32(3);
                            passager.timeToLeave = reader.GetString(4);
                            passager.Is_male = reader.GetBoolean(5);
                            passager.CreatedAt= reader.GetDateTime(6);
                            passager.UpdatedAt = reader.GetDateTime(7);
                            passager.place = reader.GetString(8);
                            passager.place1= reader.GetString(9);
                            passager.IsAktiv= reader.GetBoolean(10);
                            list.Add(passager);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Passager>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<int> UpdateAsync(long id, Passager editObj)
        {

            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Passenger\" SET is_aktiv= true WHERE  id = {id}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("is_aktiv", editObj.IsAktiv);
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


      
       
        public async Task<List<Passager>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();
                List<Passager> list = new List<Passager>();
                string query = $"SELECT * FROM public.\"Passenger\"  order by id";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Passager passager = new Passager();
                            passager.Id = reader.GetInt32(0);
                            passager.Name = reader.GetString(1);
                            passager.Phone_number = reader.GetString(2);
                            passager.thereArePassengers = reader.GetInt32(3);
                            passager.timeToLeave = reader.GetString(4);
                            passager.Is_male = reader.GetBoolean(5);
                            passager.CreatedAt = reader.GetDateTime(6);
                            passager.UpdatedAt = reader.GetDateTime(7);
                            passager.place = reader.GetString(8);
                            passager.place1= reader.GetString(9);
                            passager.IsAktiv = reader.GetBoolean(10);

                            list.Add(passager);

                        }
                    }
                }
                return list;
            }
            
            finally { await _connection.CloseAsync(); }
        }

        public async Task<List<Passager>> GetAllTrue()
        {
            try
            {
                await _connection.OpenAsync();
                List<Passager> list = new List<Passager>();
                string query = $"SELECT * FROM public.\"Passenger\" where is_aktiv = true order by id";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Passager passager = new Passager();
                            passager.Id = reader.GetInt32(0);
                            passager.Name = reader.GetString(1);
                            passager.Phone_number = reader.GetString(2);
                            passager.thereArePassengers = reader.GetInt32(3);
                            passager.timeToLeave = reader.GetString(4);
                            passager.Is_male = reader.GetBoolean(5);
                            passager.CreatedAt = reader.GetDateTime(6);
                            passager.UpdatedAt = reader.GetDateTime(7);
                            passager.place = reader.GetString(8);
                            passager.place1 = reader.GetString(9);
                            passager.IsAktiv = reader.GetBoolean(10);

                            list.Add(passager);

                        }
                    }
                }
                return list;
            }

            finally { await _connection.CloseAsync(); }
        }

        public async Task<int> UpdateAktiv(string PhoneNumber, Passager editObj)
        {

            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Passenger\" SET is_aktiv= false WHERE  phone_number = '+998{PhoneNumber}'";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("is_aktiv", editObj.IsAktiv);
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

        public async Task<int> GetPersonNum(string PhoneNumber)
        {
            try
            {
                await _connection.OpenAsync();
                int PersonNum = 0;
                string query = $"select there_are_passengers from \"Passenger\" where phone_number = '+998{PhoneNumber}' ";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                             PersonNum = reader.GetInt32(0);
                        }
                    }
                       return PersonNum;
                }
                
            }
            catch
            {
                return  0;
            }
            finally { await _connection.CloseAsync(); }
        }
    }
}
