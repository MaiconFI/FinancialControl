using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinancialControl.Api.IntegrationsTests.Queries.Expensies
{
    public class GetExpenseTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetExpenseTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task MustGetExpenseById()
        {
            var client = _factory.CreateClient();

            var expense = await ExpenseGenerator.CreateAsync(client);

            var url = $"/api/v1/expense/{expense.Id}";

            var response = await client.GetAsync(url, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ExpenseByIdQueryResult>(content);

            Assert.Equal(expense.Id, result.Expense.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/v1/expense")]
        public async Task MustGetExpensies(string url)
        {
            var client = _factory.CreateClient();

            var expense = await ExpenseGenerator.CreateAsync(client);

            var response = await client.GetAsync(url, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ExpensiesQueryResult>(content);

            Assert.Contains(result.Expensies, x => x.Id == expense.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}