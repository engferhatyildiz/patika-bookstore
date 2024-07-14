using patika_bookstore.Common;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.GetBooks;

public class GetBooksQuery(BookStoreDbContext dbContext)
{
    public List<BooksViewModel> Handle()
    {
        var bookList = dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
        List<BooksViewModel> vm = new List<BooksViewModel>();
        foreach (var book in bookList)
        {
            vm.Add(new BooksViewModel()
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount
                
            });
        }

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