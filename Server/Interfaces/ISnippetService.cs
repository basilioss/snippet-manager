using SnippetManager.Server.Models;

namespace SnippetManager.Server.Interfaces
{
    public interface ISnippetService
    {
        Task<List<Snippet>> GetSnippets();
        Task<Snippet?> GetSnippetById(int productId);
        Task<Snippet> CreateSnippet(Snippet snippet);
        Task<Snippet?> UpdateSnippet(int snippetId, Snippet snippet);
        Task<bool> DeleteSnippet(int snippetId);
    }
}
