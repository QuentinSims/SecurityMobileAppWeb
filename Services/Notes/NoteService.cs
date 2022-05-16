using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using SecurityMobileAppWeb.Models;
using System.Text;

namespace SecurityMobileAppWeb.Services.Notes
{
    public class NoteService : INote
    {
        static string BaseUrl = "https://mongodbapi89.azurewebsites.net/";

        public NoteService()
        {
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync("api/Note");
            var notes = JsonConvert.DeserializeObject<IEnumerable<Models.Note>>(json);
            return notes;

        }

        public async Task DeleteNoteAsync(string id)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/Note/{id}");
            if (response.IsSuccessStatusCode)
            {
                await Task.FromResult(true);
            }
            else
            {
                await Task.FromResult(false);
            }
        }

        public async Task AddNoteAsync(Note note)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(note);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Note", content);
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
