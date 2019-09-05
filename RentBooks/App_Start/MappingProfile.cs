using AutoMapper;
using RentBooks.Dtos;
using RentBooks.Models;

namespace RentBooks.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<BookGenre, BookGenreDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}