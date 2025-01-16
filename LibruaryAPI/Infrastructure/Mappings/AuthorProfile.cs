using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Infrastructure.Mappings
{
    /// <summary>
    /// Профиль для маппинга сущности Author.
    /// </summary>
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src => src.Books.Select(b => b.Title).ToList()));

            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());
        }
    }
}
