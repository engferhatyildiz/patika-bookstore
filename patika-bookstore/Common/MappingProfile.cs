using AutoMapper;
using patika_bookstore.BookOperations.GetBooks;
using static patika_bookstore.BookOperations.CreateBook.CreateBookCommand;
using static patika_bookstore.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace patika_bookstore.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, BookDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        CreateMap<Book,BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

    }
    
}