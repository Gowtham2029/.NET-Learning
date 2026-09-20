namespace Practice_A.DataProvider
{
    public interface IUserProvider
    {
        public Task<IEnumerable<string>>? GetUserName(string Email);
    }
}
