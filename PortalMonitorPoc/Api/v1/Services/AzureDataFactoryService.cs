using PortalMonitorPoc.Api.v1.Interfaces;
using PortalMonitorPoc.Api.v1.Models;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace PortalMonitorPoc.Api.v1.Services
{
    public class AzureDataFactoryService : IAzureDataFactoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _tenantId = "12a3af23-a769-4654-847f-958f3d479f4a";
        private readonly string _clientId = "a14149ef-1ef5-4c1d-9741-21c56349eb26";
        private readonly string _clientSecret = "HZT8Q~G8vt6NOT0j4XDLiRkHPdzSrl3Nbqms.aWb";
        private readonly string _subscriptionId = "a6c9f13d-be73-4227-b485-c7a16289be08";

        public AzureDataFactoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DataFactory>> GetDataFactoriesAsync()
        {
            var token = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://management.azure.com/subscriptions/{_subscriptionId}/providers/Microsoft.DataFactory/factories?api-version=2018-06-01");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DataFactoryResponse>(jsonResponse);
                return result.Value;
            }

            return new List<DataFactory>();
        }

        public async Task<List<PipelineRun>> GetPipelineRunsAsync(string dataFactoryName)
        {
            var token = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://management.azure.com/subscriptions/{_subscriptionId}/resourceGroups/your-resource-group/providers/Microsoft.DataFactory/factories/{dataFactoryName}/pipelineruns?api-version=2018-06-01");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PipelineRun>>(jsonResponse);
            }

            return new List<PipelineRun>();
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var app = ConfidentialClientApplicationBuilder.Create(_clientId)
                .WithClientSecret(_clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{_tenantId}"))
                .Build();

            var result = await app.AcquireTokenForClient(new[] { "https://management.azure.com/.default" }).ExecuteAsync();
            return result.AccessToken;
        }
    }
}