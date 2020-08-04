using FinancialControl.Application.Commands.Expensies.RemoveExpense;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinancialControl.Api.IntegrationsTests.Commands
{
    public class RemoveExpenseTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RemoveExpenseTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task MustRemoveExpense()
        {
            var client = _factory.CreateClient();

            var expense = await ExpenseGenerator.CreateAsync(client);

            var url = $"/api/v1/expense?id={expense.Id}";

            var response = await client.DeleteAsync(url, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RemoveExpenseCommandResult>(content);

            Assert.True(result.Valid);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}