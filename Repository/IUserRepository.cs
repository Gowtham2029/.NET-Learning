using Practice_A.Models.Authentication;

namespace Practice_A.Repository
{
    public interface IUserRepository
    {
        public Task<UserDetailsModel>? GetUserName(string Email);
    }
}
