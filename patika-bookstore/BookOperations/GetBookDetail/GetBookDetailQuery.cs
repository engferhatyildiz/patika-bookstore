using AutoMapper;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.GetBookDetail;

public class GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
{
    public int BookId { get; set; }

    public BookDetailViewModel Handle()
    {
        var book = dbContext.Books.SingleOrDefault(book => book.Id == BookId);
        if (book is null)
        {
            throw new InvalidOperationException("The Book does not found");
        }

        BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);

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