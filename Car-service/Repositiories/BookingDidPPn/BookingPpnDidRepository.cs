using Car_service.Entities.BokkingDidPpn;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Unitils;
using Car_service.Windows.Driver;
using MaterialDesignThemes.Wpf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories.BookingDidPPn
{


    public class BookingPpnDidRepository : BaseRepository, IIBookingPpnDid
    {
     

        public async Task<int> CretaAsync(BookingDidPpnEntity obj)
        {
            try
            {
                await _connection.OpenAsync();

                int result = 0;
                string query = "INSERT INTO public.\"Booking\"( p_phone_number, driver_id, is_agree) VALUES ( @p_phone_number, @driver_id, @is_agree);";


                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("id", obj.Id);
                    command.Parameters.AddWithValue("p_phone_number", obj.PassengerPhoneNumber);
                    command.Parameters.AddWithValue("is_agree", obj.IsAgree);
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
                string query = $"DELETE FROM public.\"Booking\" WHERE driver_id = {id};";
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

        public async Task<int> DeletPhoneNumberDriverId(string PassengerPhoneNumber, int DriverId)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"DELETE FROM public.\"Booking\" WHERE driver_id = {DriverId} and p_phone_number = '+998{PassengerPhoneNumber}'";
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

        public Task<IList<BookingDidPpnEntity>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookingDidPpnEntity>> GetBookingDiagnosis(string PassengerPhoneNumber, int DriverId)
        {
            try
            {
                await _connection.OpenAsync();
                List<BookingDidPpnEntity> list = new List<BookingDidPpnEntity>();
                string query = $"select * from \"Booking\" where  p_phone_number = '+998{PassengerPhoneNumber}' and driver_id = {DriverId} ;";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            BookingDidPpnEntity entity = new BookingDidPpnEntity();
                            entity.PassengerPhoneNumber = reader.GetString(1);
                            entity.DriverId = reader.GetInt32(2);
                            list.Add(entity);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<BookingDidPpnEntity>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async  Task<List<int>> GetDriverId(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();
                List<int> list = new List<int>();
                string query = $"select driver_id from \"Booking\" where = '+998{phoneNumber}' order by id ;";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int Id = reader.GetInt32(0);
                            list.Add(Id);

                        }
                    }
                }
                return list;
            }
            catch
            {
                return new List<int>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<bool> GetIsAgree(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();
                bool Isagree = false;
                string query = $"\tselect is_agree from \"Booking\" where p_phone_number = '+998{phoneNumber}' ";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            Isagree = reader.GetBoolean(0);
                        }
                    }
                       return Isagree;
                }
            }
            catch { return false; }
           
            finally { await _connection.CloseAsync(); }
        }

        public async Task<int> UpdateAsync(long id, BookingDidPpnEntity editObj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Booking\" set is_agree= @is_agree WHERE id = {id}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("is_agree", editObj.IsAgree);
                    var  dbrresult = await command.ExecuteNonQueryAsync();
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


        public async Task<int> UpdateIsAgree(string phoneNumber, BookingDidPpnEntity editObj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Booking\" set is_agree= @is_agree WHERE p_phone_number = '+998{phoneNumber}' ";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("is_agree", editObj.IsAgree);
                  
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
