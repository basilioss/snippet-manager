using Microsoft.AspNetCore.Components;
using SnippetManager.Shared;
using System.Net;
using System.Net.Http.Json;

namespace SnippetManager.Client.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;
        public SnippetService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;

        }
        public List<Snippet> Snippets { get ; set; } = new List<Snippet>();
        public async Task GetSnippets()
        {
            var result = await _http.GetFromJsonAsync<List<Snippet>>("api/snippet");
            if (result is not null)
                Snippets = result;
        }
        public async Task<Snippet?> GetSnippetById(int id)
        {
            var result = await _http.GetAsync($"api/snippet/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Snippet>();
            }
            return null;
        }
        public async Task SearchSnippets(string searchString)
        {
            var result = await _http.GetFromJsonAsync<List<Snippet>>($"api/snippet/search?searchString={searchString}");
            if (result is not null)
                Snippets = result;
        }

        public async Task CreateSnippet(Snippet snippet)
        {
            await _http.PostAsJsonAsync("api/snippet", snippet);
            _navigationManger.NavigateTo("/app");
        }

        public async Task DeleteSnippet(int id)
        {
            await _http.DeleteAsync($"api/snippet/{id}");
            _navigationManger.NavigateTo("/app");
        }

        public async Task UpdateSnippet(int id, Snippet snippet)
        {
            await _http.PutAsJsonAsync($"api/snippet/{id}", snippet);
            _navigationManger.NavigateTo("/app");
        }
    }
}
