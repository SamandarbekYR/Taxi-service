using Car_service.Entities.DriverFriends;
using Car_service.Entities.orderview;
using Car_service.Interfaces.orders;
using Car_service.Unitils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_service.Repositiories.orderR
{
    public class OrderRepository : BaseRepository, IOrder
    {
        public Task<int> CretaAsync(Orderviews obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Orderviews>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Orderviews>> Search(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();
                List<Orderviews> list = new List<Orderviews>();
                string query = $"select * from \"order\"  where p_phone_number = '+998{phoneNumber}' ;";

                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Orderviews orderviews = new Orderviews();
                            orderviews.BookingId = reader.GetInt32(0);
                            orderviews.Name = reader.GetString(1);
                            orderviews.Score = reader.GetInt32(2);
                            orderviews.ImagePath= reader.GetString(3);
                            orderviews.Booked  = reader.GetInt32(4);
                            orderviews.place1 = reader.GetString(5);
                            orderviews.IsToshket = reader.GetBoolean(6);
                            orderviews.PhoneNumber = reader.GetString(7);
                            orderviews.DriverId = reader.GetInt32(8);
                            orderviews.PassengerPhoneNumber= reader.GetString(9);
                            orderviews.IsAgree= reader.GetBoolean(10);
                            orderviews.ThereArePassengers = reader.GetInt32(11);
                            orderviews.TimeToLeave = reader.GetString(12);
                            orderviews.IsMale= reader.GetBoolean(13);
                            orderviews.PassengerName= reader.GetString(14);
                            orderviews.wherefrom  = reader.GetString(15);
                            orderviews.Whereto = reader.GetString(16);
                            list.Add(orderviews);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Orderviews>();
            }
            finally { await _connection.CloseAsync(); }


        }

        public async Task<List<Orderviews>> SearchDriverInfo(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();
                List<Orderviews> list = new List<Orderviews>();
                string query = $"select * from \"order\"  where p_phone_number = '+998{phoneNumber}' and is_agree = true ;";

                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Orderviews orderviews = new Orderviews();
                            orderviews.BookingId = reader.GetInt32(0);
                            orderviews.Name = reader.GetString(1);
                            orderviews.Score = reader.GetInt32(2);
                            orderviews.ImagePath = reader.GetString(3);
                            orderviews.Booked = reader.GetInt32(4);
                            orderviews.place1 = reader.GetString(5);
                            orderviews.IsToshket = reader.GetBoolean(6);
                            orderviews.PhoneNumber = reader.GetString(7);
                            orderviews.DriverId = reader.GetInt32(8);
                            orderviews.PassengerPhoneNumber = reader.GetString(9);
                            orderviews.IsAgree = reader.GetBoolean(10);
                            orderviews.ThereArePassengers = reader.GetInt32(11);
                            orderviews.TimeToLeave = reader.GetString(12);
                            orderviews.IsMale = reader.GetBoolean(13);
                            orderviews.PassengerName = reader.GetString(14);
                            orderviews.wherefrom = reader.GetString(15);
                            orderviews.Whereto = reader.GetString(16);
                            list.Add(orderviews);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Orderviews>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<List<Orderviews>> SearchPassengerAgree(int id)
        {
            try
            {
                await _connection.OpenAsync();
                List<Orderviews> list = new List<Orderviews>();
                string query = $"select * from \"order\"  where driver_id = {id} and is_agree = true ;";

                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Orderviews orderviews = new Orderviews();
                            orderviews.BookingId = reader.GetInt32(0);
                            orderviews.Name = reader.GetString(1);
                            orderviews.Score = reader.GetInt32(2);
                            orderviews.ImagePath = reader.GetString(3);
                            orderviews.Booked = reader.GetInt32(4);
                            orderviews.place1 = reader.GetString(5);
                            orderviews.IsToshket = reader.GetBoolean(6);
                            orderviews.PhoneNumber = reader.GetString(7);
                            orderviews.DriverId = reader.GetInt32(8);
                            orderviews.PassengerPhoneNumber = reader.GetString(9);
                            orderviews.IsAgree = reader.GetBoolean(10);
                            orderviews.ThereArePassengers = reader.GetInt32(11);
                            orderviews.TimeToLeave = reader.GetString(12);
                            orderviews.IsMale = reader.GetBoolean(13);
                            orderviews.PassengerName = reader.GetString(14);
                            orderviews.wherefrom = reader.GetString(15);
                            orderviews.Whereto = reader.GetString(16);
                            list.Add(orderviews);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<Orderviews>();
            }
            finally { await _connection.CloseAsync(); }

        }

        public Task<int> UpdateAsync(long id, Orderviews editObj)
        {
            throw new NotImplementedException();
        }
    }
}
