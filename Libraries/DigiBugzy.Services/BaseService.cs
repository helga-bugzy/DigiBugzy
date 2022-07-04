

namespace DigiBugzy.Services
{
    public class BaseService: IDisposable
    {
        private string _connectionString;

        public DatabaseContext dbContext;

        public BaseService(string connectionString)
        {
            _connectionString = connectionString;
            dbContext = new DatabaseContext(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
