using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Api.IntegrationsTests
{
    public class ExpenseGenerator
    {
        public static async Task<CreateExpenseResult> CreateAsync(HttpClient client)
        {
            var command = new
            {
                Category = "test",
                Description = "test",
                Value = 100
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "text/json");

            var response = await client.PostAsync("/api/v1/expense", requestContent, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CreateExpenseResult>(content);
        }
    }
}