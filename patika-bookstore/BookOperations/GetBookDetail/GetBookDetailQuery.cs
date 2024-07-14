using patika_bookstore.Common;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.GetBookDetail;

public class GetBookDetailQuery(BookStoreDbContext dbContext)
{
    public int BookId { get; set; }

    public BookDetailViewModel Handle()
    {
        var book = dbContext.Books.SingleOrDefault(book => book.Id == BookId);
        if (book is null)
        {
            throw new InvalidOperationException("The Book does not found");
        }

        BookDetailViewModel vm = new BookDetailViewModel();
        vm.Title = book.Title;
        vm.PageCount = book.PageCount;
        vm.PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy");
        vm.Genre = ((GenreEnum)book.GenreId).ToString();

        return vm;
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}