using Practice_A.Models.Authentication;

namespace Practice_A.DataProvider
{
    public interface IUserProvider
    {
        public Task<UserDetailsModel>? GetUserName(string Email);
    }
}
