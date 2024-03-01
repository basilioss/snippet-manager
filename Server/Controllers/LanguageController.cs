using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnippetManager.Server.DTOs;
using SnippetManager.Server.Models;
using SnippetManager.Server.Services;

namespace SnippetManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<List<LanguageDto>> GetLanguages()
        {
            return await _languageService.GetLanguages();
        }
    }
}
