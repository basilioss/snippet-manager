using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnippetManager.Server.Interfaces;
using SnippetManager.Server.Models;
using System.Security.Claims;
using SnippetManager.Server.DTOs;
using System.Security.Principal;

namespace SnippetManager.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetController : ControllerBase
    {
        private readonly ISnippetService _snippetService;

        public SnippetController(ISnippetService snippetService)
        {
            _snippetService = snippetService;
        }

        [HttpGet]
        public async Task<List<Snippet>> GetSnippets()
        {
            return await _snippetService.GetSnippets(GetUserId(User));
        }

        [HttpGet("{id}")]
        public async Task<Snippet?> GetSnippetById(int id)
        {
            return await _snippetService.GetSnippetById(id);
        }

        [HttpPost]
        public async Task<Snippet?> CreateSnippet(SnippetDto createSnippetDto)
        {
            return await _snippetService.CreateSnippet(GetUserId(User), createSnippetDto);
        }

        [HttpPut("{id}")]
        public async Task<Snippet?> UpdateSnippet(int id, SnippetDto snippet)
        {
            return await _snippetService.UpdateSnippet(id, snippet);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSnippet(int id)
        {
            return await _snippetService.DeleteSnippet(id);
        }
        private string GetUserId(IPrincipal user)
        {
            var userIdClaim = (user.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}
