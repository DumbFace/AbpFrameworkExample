using AutoMapper;
using BookStore.Authors;
using BookStore.Books;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book,BookDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateBookDto,Book>();
    }
}
