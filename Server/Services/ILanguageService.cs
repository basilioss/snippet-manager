using SnippetManager.Server.DTOs;
using SnippetManager.Server.Models;

namespace SnippetManager.Server.Services
{
    public interface ILanguageService
    {
        Task<List<LanguageDto>> GetLanguages();
    }
}
