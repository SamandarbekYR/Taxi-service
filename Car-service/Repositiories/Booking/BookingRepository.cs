using Car_service.Entities.Booking;
using Car_service.Interfaces.Booking;
using Car_service.Unitils;
using Car_service.ViewModels.Booking;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_service.Repositiories.Booking
{
    public class BookingRepository :BaseRepository, IBookingRepository
    {
      
        public Task<int> CretaAsync(booking obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BookingViewModel>> GetList(string DriverName)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "select * from booking_view" +
                              "where driver = @driver";


                await using(var command = new NpgsqlCommand(query,_connection))
                {
                    command.Parameters.AddWithValue("driver", DriverName);
                     List<BookingViewModel> model = new List<BookingViewModel>();
                    
                    await using (var reader = await command.ExecuteReaderAsync()) 
                    {
                
                        while(await reader.ReadAsync())
                        {
                            BookingViewModel viewModel = new BookingViewModel();
                            viewModel.Id = reader.GetInt64(0);
                            viewModel.DriverName= reader.GetString(1);
                            viewModel.PassengerInformation = reader.GetString(2);
                            viewModel.StartPlace = reader.GetString(3);
                            viewModel.EndPlace = reader.GetString(4);
                            viewModel.CreatedAt = reader.GetDateTime(5);
                            viewModel.UpdatedAt = reader.GetDateTime(6);
                            model.Add(viewModel);
                        }
                        
                    }
               return model;
                }
                
            }
            catch
            {
                return new List<BookingViewModel>();
            }
            finally { await _connection.CloseAsync(); }
           
         
        }

        public Task<IList<BookingViewModel>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BookingViewModel>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, booking editObj)
        {
            throw new NotImplementedException();
        }

        Task<BookingViewModel> IBookingRepository.GetList(string DriverName)
        {
            throw new NotImplementedException();
        }
    }
}
