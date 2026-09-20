using Dapper;
using MySqlConnector;
using Practice_A.DataProvider;

namespace Practice_A.DataProvider
{
    public class UserProvider : IUserProvider
    {
        IConfiguration _configuration;
        public UserProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<string>>? GetUserName(string Email)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // SET SQL_SAFE_UPDATES = 0; --> use this before delete, update commands

            var sql = "select name from User";
            using var connection = new MySqlConnection(connectionString);

            var users = await connection.QueryAsync<string>(sql);
            return users;
        }
    }
}
