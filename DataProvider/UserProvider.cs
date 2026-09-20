using Dapper;
using MySqlConnector;
using Practice_A.DataProvider;
using Practice_A.Models.Authentication;

namespace Practice_A.DataProvider
{
    public class UserProvider : IUserProvider
    {
        IConfiguration _configuration;
        public UserProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<UserDetailsModel>? GetUserName(string Email)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

           
            // SET SQL_SAFE_UPDATES = 0; --> use this before delete, update commands
            var sql = "SELECT * FROM USER WHERE Email = @Email";
            using var connection = new MySqlConnection(connectionString);

            var user = await connection.QueryFirstOrDefaultAsync<UserDetailsModel>(sql, new { Email });
            return user;
        }
    }
}

