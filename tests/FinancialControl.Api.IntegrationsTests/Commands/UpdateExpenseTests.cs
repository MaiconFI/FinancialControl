using FinancialControl.Application.Commands.Expensies.RemoveExpense;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinancialControl.Api.IntegrationsTests.Commands
{
    public class UpdateExpenseTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UpdateExpenseTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/expense")]
        public async Task MustUpdateExpense(string url)
        {
            var client = _factory.CreateClient();

            var expense = await ExpenseGenerator.CreateAsync(client);

            var command = new
            {
                Category = "update test",
                Description = "update test",
                Id = expense.Id,
                Value = 10000
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "text/json");

            var response = await client.PutAsync(url, requestContent, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RemoveExpenseCommandResult>(content);

            Assert.True(result.Valid);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}