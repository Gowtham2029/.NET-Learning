using Microsoft.AspNetCore.Mvc;

namespace Practice_A.Services
{
    public interface ITestService
    {
       public Guid Id { get; set; }

        public string GetGreetMessage(string userName);
    }
}
