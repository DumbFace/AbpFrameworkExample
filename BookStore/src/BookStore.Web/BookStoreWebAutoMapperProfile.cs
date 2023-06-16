using AutoMapper;
using BookStore.Authors;
using BookStore.Books;

namespace BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();

        // ADD a NEW MAPPING
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,
                  CreateAuthorDto>();

        // ADD THESE NEW MAPPINGS
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
                  UpdateAuthorDto>();
    }
}
