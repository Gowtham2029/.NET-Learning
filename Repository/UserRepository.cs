using Practice_A.DataProvider;
using Practice_A.Models.Authentication;
namespace Practice_A.Repository
{
    public class UserRepository : IUserRepository
    {
        IUserProvider userProvider;
        public UserRepository(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }
        public async Task<UserDetailsModel>? GetUserName(string Email)
        {
            var user = await userProvider.GetUserName(Email);
            return user;
        }
    }
}
