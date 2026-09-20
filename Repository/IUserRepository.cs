namespace Practice_A.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<string>>? GetUserName(string Email);
    }
}
