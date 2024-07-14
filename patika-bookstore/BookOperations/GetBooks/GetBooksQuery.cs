using AutoMapper;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.GetBooks;

public class GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
{
    public List<BooksViewModel> Handle()
    {
        var bookList = dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
        List<BooksViewModel> vm = mapper.Map<List<BooksViewModel>>(bookList);
        
        return vm;
    }
}

public class BooksViewModel
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
}