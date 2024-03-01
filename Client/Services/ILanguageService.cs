using SnippetManager.Shared;

namespace SnippetManager.Client.Services
{
    public interface ILanguageService
    {
        List<Language> Languages { get; set; }
        Task GetLanguages();
    }
}
