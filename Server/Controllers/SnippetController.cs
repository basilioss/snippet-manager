using Microsoft.AspNetCore.Mvc;
using SnippetManager.Server.Interfaces;
using SnippetManager.Shared;

namespace SnippetManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetController : ControllerBase
    {
        private readonly ISnippetService _snippetService;

        public SnippetController(ISnippetService productService)
        {
            _snippetService = productService;
        }

        [HttpGet]
        public async Task<List<Snippet>> GetSnippets()
        {
            return await _snippetService.GetSnippets();
        }

        [HttpGet("{id}")]
        public async Task<Snippet?> GetSnippetById(int id)
        {
            return await _snippetService.GetSnippetById(id);
        }

        [HttpPost]
        public async Task<Snippet?> CreateProduct(Snippet snippet)
        {
            return await _snippetService.CreateSnippet(snippet);
        }

        [HttpPut("{id}")]
        public async Task<Snippet?> UpdateProduct(int id, Snippet snippet)
        {
            return await _snippetService.UpdateSnippet(id, snippet);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _snippetService.DeleteSnippet(id);
        }
    }
}
