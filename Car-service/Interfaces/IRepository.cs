using Car_service.Unitils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces
{
    public interface IRepository<TModel,TViewModel>
    {
        public Task<int> CretaAsync(TModel obj);
        public Task<int> UpdateAsync(long id, TModel editObj);
        public Task<int> DeleteAsync(long id);
        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params); 
    }
}
