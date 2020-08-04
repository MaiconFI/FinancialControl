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
    public class CreateExpenseTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CreateExpenseTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/v1/expense")]
        public async Task MustCreateExpense(string url)
        {
            var client = _factory.CreateClient();

            var command = new
            {
                Category = "test",
                Description = "test",
                Value = 100
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "text/json");

            var response = await client.PostAsync(url, requestContent, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CreateExpenseResult>(content);

            Assert.True(result.Valid);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}