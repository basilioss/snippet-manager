using SnippetManager.Server.Models;
using SnippetManager.Server.DTOs;

namespace SnippetManager.Server.Services
{
    public interface ISnippetService
    {
        Task<List<Snippet>> GetSnippets(string userId);
        Task<Snippet?> GetSnippetById(int snippetId);
        Task<List<Snippet>> SearchSnippets(string userId, string? searchString);
        Task<Snippet> CreateSnippet(string userId, SnippetDto createSnippetDto);
        Task<Snippet?> UpdateSnippet(int snippetId, SnippetDto updateSnippetDto);
        Task<bool> DeleteSnippet(int snippetId);
    }
}
