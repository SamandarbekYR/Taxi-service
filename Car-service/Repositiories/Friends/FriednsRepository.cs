using Car_service.Entities.DriverFriends;
using Car_service.Interfaces.Friends;
using Car_service.Unitils;
using Car_service.ViewModels.RatingViewModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories.Friends
{
    public class FriednsRepository :BaseRepository, IFriendsRepository
    {
        public async Task<List<driverFriend>> CheckId(int id)
        {
            try
            {
                await _connection.OpenAsync();
                List<driverFriend> list = new List<driverFriend>();
                string query = $"select * from friends  where driver_id = {id} ;";
                                                      
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            driverFriend Friend = new driverFriend();
                            Friend.ImagePath = reader.GetString(1);
                            Friend.Name = reader.GetString(2);
                            Friend.PhoneNumber = reader.GetString(3);
                            Friend.Score = reader.GetInt32(4);
                            Friend.IsToshkent = reader.GetBoolean(5);
                            Friend.City = reader.GetString(6);
                            Friend.DriverId = reader.GetInt32(7);

                            list.Add(Friend);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<driverFriend>();
            }
            finally { await _connection.CloseAsync(); }


        }

        public async Task<int> CretaAsync(driverFriend obj)
        {
            try
            {
                await _connection.OpenAsync();

                int result = 0;
                string query = " INSERT INTO public.friends( image, name, phone_number, score, is_toshkent, city, driver_id) VALUES (@image, @name, @phone_number, @score, @is_toshkent, @city, @driver_id);";


                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("id", obj.Id);
                    command.Parameters.AddWithValue("image", obj.ImagePath);
                    command.Parameters.AddWithValue("name", obj.Name);
                    command.Parameters.AddWithValue("phone_number", obj.PhoneNumber);
                    command.Parameters.AddWithValue("score", obj.Score);
                    command.Parameters.AddWithValue("is_toshkent", obj.IsToshkent);
                    command.Parameters.AddWithValue("city", obj.City);
                    command.Parameters.AddWithValue("driver_id", obj.DriverId);
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

        public async Task<int> DeleteAsync(long id)
        { 
                try
            { 
                    await _connection.OpenAsync();
                    string query = $"DELETE FROM public.friends WHERE driver_id = {id}";
                    await using (var command = new NpgsqlCommand(query, _connection))
                    {
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

        public List<driverFriend> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<driverFriend>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                List<driverFriend> list = new List<driverFriend>();
                string query = $"select * from friends order by score desc offset " +
                    $"{(@params.PageNumber-1)*@params.PageSize}" +
                    $" limit {@params.PageSize}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            driverFriend Friend = new driverFriend();
                            Friend.ImagePath = reader.GetString(1);
                            Friend.Name = reader.GetString(2);
                            Friend.PhoneNumber = reader.GetString(3);
                            Friend.Score = reader.GetInt32(4);
                            Friend.IsToshkent = reader.GetBoolean(5);
                            Friend.City= reader.GetString(6);
                            Friend.DriverId = reader.GetInt32(7);   

                            list.Add(Friend);

                        }
                    }          
                }
                return list;
            }
            catch
            {
                return new  List<driverFriend>();
            }
            finally { await _connection.CloseAsync(); }
        

        }

        public Task<int> UpdateAsync(long id, driverFriend editObj)
        {
            throw new NotImplementedException();
        }

        Task<List<driverFriend>> IFriendsRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
