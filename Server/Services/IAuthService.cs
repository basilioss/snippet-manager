using SnippetManager.Server.Models;

namespace SnippetManager.Server.Services
{
    public interface IAuthService
    {
        Task Register(LoginUser loginUser);
        Task<string> Login(LoginUser user);
    }
}