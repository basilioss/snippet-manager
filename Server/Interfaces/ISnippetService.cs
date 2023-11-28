using SnippetManager.Server.Models;
using SnippetManager.Server.DTOs;

namespace SnippetManager.Server.Interfaces
{
    public interface ISnippetService
    {
        Task<List<Snippet>> GetSnippets(string userId);
        Task<Snippet?> GetSnippetById(int productId);
        Task<Snippet> CreateSnippet(string userId, SnippetDto createSnippetDto);
        Task<Snippet?> UpdateSnippet(int snippetId, SnippetDto updateSnippetDto);
        Task<bool> DeleteSnippet(int snippetId);
    }
}
