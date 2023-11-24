using SnippetManager.Server.Models;

namespace SnippetManager.Server.Interfaces
{
    public interface IAuthService
    {
        Task Register(LoginUser loginUser);
        Task<string> Login(LoginUser user);
    }
}