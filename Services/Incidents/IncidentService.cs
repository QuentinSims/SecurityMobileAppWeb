using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using SecurityMobileAppWeb.Models;
using System.Text;

namespace SecurityMobileAppWeb.Services.Incidents
{
    public class IncidentService : IIncident
    {
        static string BaseUrl = "https://mongodbapi89.azurewebsites.net/";
        public IncidentService()
        {
        }
        public async Task AddIncidentAsync(Incident incident)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(incident);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Incident", content);
            if (response.IsSuccessStatusCode)
            {
                await Task.FromResult(true);
            }
            else
            {
                await Task.FromResult(false);
            }
        }
        public async Task DeleteIncidentAsync(string id)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/Indient/{id}");
            if (response.IsSuccessStatusCode)
            {
                await Task.FromResult(true);
            }
            else
            {
                await Task.FromResult(false);
            }
        }
        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync("api/Incident");
            var incidents = JsonConvert.DeserializeObject<IEnumerable<Models.Incident>>(json);
            return incidents;
        }
        private string GetToken()
        {
            AuthenticationContext context = new AuthenticationContext(ApiSettings.authority);
            ClientCredential clientCredential = new ClientCredential(ApiSettings.clientId, ApiSettings.clientSecret);
            return context.AcquireTokenAsync(ApiSettings.resource, clientCredential).Result.AccessToken;
        }
    }
}
