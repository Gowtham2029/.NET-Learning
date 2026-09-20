using Microsoft.AspNetCore.Mvc;
using Practice_A.Services;

namespace Practice_A.Services
{
    public class TestService : ITestService
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string GetGreetMessage(string userName)
        {
            string GreetMessage = "Hello " + userName + " Welcome to ASP.NET Core Web APIs";
            return GreetMessage;
        }

       
    }
}
