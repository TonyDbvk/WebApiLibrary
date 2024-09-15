using AutoMapper;
using Library.API.DTOs;
using Library.Domain.Models;

namespace Library.API.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author,
                           opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}")).ReverseMap();

        }
    }
}
