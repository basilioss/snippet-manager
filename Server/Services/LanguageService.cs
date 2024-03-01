using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SnippetManager.Server.Data;
using SnippetManager.Server.DTOs;
using SnippetManager.Server.Models;

namespace SnippetManager.Server.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LanguageService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LanguageDto>> GetLanguages()
        {
            var languages = await _context.Languages.ToListAsync();
            return _mapper.Map<List<LanguageDto>>(languages);
        }
    }
}
