using Billing.Performance.Test;
using NBomber.Contracts;
using NBomber.CSharp;
using System.Net.Http.Json;

namespace NBomberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7114/");

            var step = Step.Create("GetBillings", async context =>
            {
                var response = await httpClient.GetAsync("api/Billing");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step2 = Step.Create("PostBilling", async context =>
            {
                BillingPost post = new BillingPost
                {
                    CPF = CPFUtils.GerarCpf(),
                    DueDate = DateTime.Now,
                    ChargeAmount = 1234
                };

                var response = await httpClient.PostAsJsonAsync($"api/Billing", post);

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            NBomberRunner
                .RegisterScenarios(ScenarioBuilder.CreateScenario("GetBillingsRequest", step))
                .Run();

            NBomberRunner
                .RegisterScenarios(ScenarioBuilder.CreateScenario("PostBillingRequest", step2))
                .Run();
        }
    }
}