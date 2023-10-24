using Car_service.Constants;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Repositiories
{
    public abstract class BaseRepository
    {
        protected NpgsqlConnection _connection;
        public BaseRepository()
        {
            _connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING);

        }

    }
}
