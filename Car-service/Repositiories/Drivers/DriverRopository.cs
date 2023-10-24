using Car_service.Constants;
using Car_service.Entities.DriverFriends;
using Car_service.Entities.Drivers;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.Drivers;
using Car_service.Unitils;
using Car_service.Windows.Driver;
using MaterialDesignThemes.Wpf;
using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories.Drivers
{

    internal class DriverRopository : IDriverRepository
    {
        private readonly NpgsqlConnection _connection;

        public  DriverRopository()
        {
            _connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING);
        }
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CretaAsync(DriverEntitiy obj)
        {
            try
            {
                await _connection.OpenAsync();

                int result = 0;
                string query = "INSERT INTO \"Driver\" ( name, phone_number, login, rating, image_path, prava_seria, booked,city, working, created_at, updated_at, password_hash, salt, IsToshkent) VALUES (@name, @phone_number, @login, @rating, @image_path, @prava_seria,@booked, @city, @working, @created_at, @updated_at, @password_hash, @salt, @IsToshkent);";
                

                await using ( var command = new NpgsqlCommand(query,_connection))
                {
                    command.Parameters.AddWithValue("image_path", obj.ImagePath);
                    command.Parameters.AddWithValue("name", obj.Name);
                    command.Parameters.AddWithValue("phone_number", obj.Phone_number);
                    command.Parameters.AddWithValue("prava_seria", obj.Prava);
                    command.Parameters.AddWithValue("rating", obj.Rating);
                    command.Parameters.AddWithValue("city", obj.City1);
                    command.Parameters.AddWithValue("booked", obj.Booked);
                    command.Parameters.AddWithValue("working", obj.working);
                    command.Parameters.AddWithValue("login", obj.Login);
                    command.Parameters.AddWithValue("password_hash", obj.PasswordHash);
                    command.Parameters.AddWithValue("salt", obj.Salt);
                    command.Parameters.AddWithValue("IsToshkent", obj.IsToshkent);
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

        public Task<List<DriverEntitiy>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<DriverEntitiy>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                IList<DriverEntitiy> list = new List<DriverEntitiy>();
                string query = $"select * from \"Driver\" order by rating desc offset " +
                    $"{(@params.PageNumber - 1) * @params.PageSize}" +
                    $" limit {@params.PageSize}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            DriverEntitiy driver = new DriverEntitiy();
                            driver.Id = reader.GetInt32(0);
                            driver.Name = reader.GetString(1);
                            driver.Phone_number = reader.GetString(2);
                            driver.Login = reader.GetString(3);
                            driver.Rating= reader.GetInt32(4);
                            driver.ImagePath = reader.GetString(5);
                            driver.Prava = reader.GetString(6);
                            driver.City1 = reader.GetString(8);
                            driver.PasswordHash = reader.GetString(12);
                            driver.Salt = reader.GetString(13);

                            list.Add(driver);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<DriverEntitiy>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<List<DriverEntitiy>> GetAsync(int id)
        {
            try
            {
                await _connection.OpenAsync();
                List<DriverEntitiy> list = new List<DriverEntitiy>();
                string query = $"SELECT * FROM public.\"Driver\" where id = {id}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DriverEntitiy driver = new DriverEntitiy();
                            driver.Id = reader.GetInt32(0);
                            driver.Name= reader.GetString(1);
                            driver.Phone_number= reader.GetString(2);
                            driver.Login= reader.GetString(3);
                            driver.ImagePath= reader.GetString(5);
                            driver.Prava = reader.GetString(6);
                            driver.City1 = reader.GetString(8);
                            driver.PasswordHash= reader.GetString(12);
                            driver.Salt= reader.GetString(13);

                            list.Add(driver);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<DriverEntitiy>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public Task<int> GetPersonNum(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(long id, DriverEntitiy editObj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Driver\" SET name =@name, " +
                                $"phone_number =@phone_number, login =@login, " +
                                $"image_path =@image_path, prava_seria =@prava_seria, " +
                                $"city =@city, updated_at =@updated_at, " +
                                $"password_hash =@password_hash, salt =@salt " +
                                $"WHERE id = {int.Parse(DriverLogin.textId.Text)}; ";
                await using (var command = new NpgsqlCommand(query, _connection))
                {


                    command.Parameters.AddWithValue("image_path", editObj.ImagePath);
                    command.Parameters.AddWithValue("name", editObj.Name);
                    command.Parameters.AddWithValue("phone_number", editObj.Phone_number);
                    command.Parameters.AddWithValue("prava_seria", editObj.Prava);
                    command.Parameters.AddWithValue("city", editObj.City1);
                    command.Parameters.AddWithValue("login", editObj.Login);
                    command.Parameters.AddWithValue("password_hash", editObj.PasswordHash);
                    command.Parameters.AddWithValue("salt", editObj.Salt);
                    command.Parameters.AddWithValue("updated_at", editObj.UpdatedAt);

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

        public async Task<int> UpdateBooked(string PhoneNumber, DriverEntitiy editObj, int number)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Driver\"  SET booked= booked+{number}  WHERE phone_number = '+998{PhoneNumber}';";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("booked", editObj.Booked);
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

        public async Task<int> UpdateBookedMinus(string PhoneNumber, DriverEntitiy editObj, int number)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Driver\"  SET booked= booked-{number}  WHERE phone_number = '+998{PhoneNumber}';";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("booked", editObj.Booked);
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

        public async Task<int> UpdateBookedZero(int id, DriverEntitiy editObj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Driver\"  SET booked= 0  WHERE id = {id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("booked", editObj.Booked);
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
