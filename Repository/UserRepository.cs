using Practice_A.DataProvider;
namespace Practice_A.Repository
{
    public class UserRepository : IUserRepository
    {
        IUserProvider userProvider;
        public UserRepository(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }
        public async Task<IEnumerable<string>>? GetUserName(string Email)
        {
            var userName = await userProvider.GetUserName(Email);
            return userName;
        }
    }
}
