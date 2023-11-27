using Microsoft.EntityFrameworkCore;
using SnippetManager.Server.Interfaces;
using SnippetManager.Server.Data;
using SnippetManager.Shared;
using SnippetManager.Client.Pages;
using Snippet = SnippetManager.Shared.Snippet;

namespace SnippetManager.Server.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ApplicationDbContext _context;

        public SnippetService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Snippet>> GetSnippets()
        {
            return await _context.Snippets.ToListAsync();
        }

        public async Task<Snippet?> GetSnippetById(int snippetId)
        {
            var dbSnippet = await _context.Snippets.FindAsync(snippetId);
            return dbSnippet;
        }

        public async Task<Snippet> CreateSnippet(Snippet snippet)
        {
            _context.Add(snippet);
            await _context.SaveChangesAsync();
            return snippet;
        }

        public async Task<Snippet?> UpdateSnippet(int snippetId, Snippet snippet)
        {
            var dbSnippet = await _context.Snippets.FindAsync(snippetId);
            if (dbSnippet != null)
            {
                dbSnippet.Title = snippet.Title;
                dbSnippet.Body = snippet.Body;

                await _context.SaveChangesAsync();
            }

            return dbSnippet;
        }

        public async Task<bool> DeleteSnippet(int snippetId)
        {
            var dbSnippet = await _context.Snippets.FindAsync(snippetId);
            if (dbSnippet == null)
            {
                return false;
            }

            _context.Remove(dbSnippet);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
