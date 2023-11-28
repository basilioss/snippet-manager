using Microsoft.EntityFrameworkCore;
using SnippetManager.Server.Data;
using Snippet = SnippetManager.Server.Models.Snippet;
using AutoMapper;
using SnippetManager.Server.DTOs;

namespace SnippetManager.Server.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SnippetService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Snippet>> GetSnippets(string userId)
        {
            return await _context.Snippets
                .Where(snippet => snippet.ApplicationUserId == userId)
                .ToListAsync();
        }

        public async Task<Snippet?> GetSnippetById(int snippetId)
        {
            var dbSnippet = await _context.Snippets.FindAsync(snippetId);
            return dbSnippet;
        }
        public async Task<List<Snippet>> SearchSnippets(string userId, string? searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return await GetSnippets(userId);
            }

            return await _context.Snippets
                .Where(snippet => snippet.ApplicationUserId == userId)
                .Where(snippet => snippet.Title.ToLower().Contains(searchString.ToLower()))
                .ToListAsync();
        }

        public async Task<Snippet> CreateSnippet(string userId, SnippetDto snippetDto)
        {
            var snippet = _mapper.Map<SnippetDto, Snippet>(snippetDto);
            snippet.ApplicationUserId = userId;

            _context.Add(snippet);
            await _context.SaveChangesAsync();

            return snippet;
        }

        public async Task<Snippet?> UpdateSnippet(int snippetId, SnippetDto snippetDto)
        {
            var dbSnippet = await _context.Snippets.FindAsync(snippetId);
            if (dbSnippet != null)
            {
                _mapper.Map(snippetDto, dbSnippet);

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
