using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System.Text;

namespace SecurityMobileAppWeb.Services.Locations
{
    public class LocationService : ILocation
    {
        static string BaseUrl = "https://mongodbapi89.azurewebsites.net/";
        public LocationService()
        {
        }

        public async Task<IEnumerable<Models.Location>> GetAllLocationsAsync()
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync("api/Location");
            var locations = JsonConvert.DeserializeObject<IEnumerable<Models.Location>>(json);
            return locations;
        }

        public async Task AddLocationAsync(Models.Location location)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Location", content);
            if (response.IsSuccessStatusCode)
            {
                await Task.FromResult(true);
            }
            else
            {
                await Task.FromResult(false);
            }
        }

        public async Task DeleteLocationAsync(string id)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/Location/{id}");
            if (response.IsSuccessStatusCode)
            {
                await Task.FromResult(true);
            }
            else
            {
                await Task.FromResult(false);
            }
        }

        private string GetToken()
        {
            AuthenticationContext context = new AuthenticationContext(ApiSettings.authority);
            ClientCredential clientCredential = new ClientCredential(ApiSettings.clientId, ApiSettings.clientSecret);
            return context.AcquireTokenAsync(ApiSettings.resource, clientCredential).Result.AccessToken;
        }
    }
}
