namespace Car_service.Constants
{
    public class DBConstants
    {
        public const string DB_HOST = "localhost";
        public const string DB_PORT = "5432";
        public const string DB_USER = "postgres";
        public const string DATABASE = "taxi-service-db";
        public const string PASSWORD = "1234";
        public const string DB_CONNECTION_STRING =
         $"Host = {DB_HOST};" +
         $"Port = {DB_PORT};" +
         $"Database = {DATABASE};" +
         $"User Id = {DB_USER};" +
         $"Password = {PASSWORD};";




    }
}
