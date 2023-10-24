using Car_service.Entities.DriverFriends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Interfaces.Friends
{
    public  interface IFriendsRepository:IRepository<driverFriend,driverFriend>
    {
        public Task<List<driverFriend>> GetAll();
        public Task<List<driverFriend>> CheckId(int id);
    }
}
