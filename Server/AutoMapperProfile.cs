using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using SnippetManager.Server.Models;
using SnippetManager.Server.DTOs;

namespace SnippetManager.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(IServer _server)
        {
            CreateMap<Snippet, SnippetDto>();
            CreateMap<SnippetDto, Snippet>();
        }
    }
}
