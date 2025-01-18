using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Application.Mappings
{
    /// <summary>
    /// Профиль для маппинга сущности Book.
    /// </summary>
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.LastName));

            CreateMap<BookDto, Book>();
        }
    }
}
