using Microsoft.AspNetCore.Components;
using SnippetManager.Client.Pages;
using SnippetManager.Shared;
using System.Net.Http.Json;

namespace SnippetManager.Client.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly HttpClient _http;
        public LanguageService(HttpClient http)
        {
            _http = http;
        }
        public List<Language> Languages { get; set; } = new List<Language>();

        public async Task GetLanguages()
        {
            var result = await _http.GetFromJsonAsync<List<Language>>("api/language");
            if (result is not null)
                Languages = result;
        }
    }
}