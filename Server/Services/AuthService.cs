using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SnippetManager.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using SnippetManager.Server.Exceptions;
using SnippetManager.Server.Resources;

namespace SnippetManager.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task Register(LoginUser loginUser)
        {
            var user = new ApplicationUser
            {
                UserName = loginUser.UserName,
                Email = loginUser.UserName
            };

            var result = await _userManager.CreateAsync(user, loginUser.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task<string> Login(LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUser.Password))
            {
                throw new HttpException(ErrorMessages.InvalidCredentials, HttpStatusCode.BadRequest);
            }

            await _signInManager.SignInAsync(user, isPersistent: true);

            return GenerateToken(user);
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
