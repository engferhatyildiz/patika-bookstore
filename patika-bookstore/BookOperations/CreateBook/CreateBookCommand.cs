using AutoMapper;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.CreateBook;

public class CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
{
    public CreateBookModel Model { get; set; }

    public void Handle()
    {
        var book = dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

        if (book is not null)
        {
            throw new InvalidOperationException("The book is already exist");
        }

        book = mapper.Map<Book>(Model);

        dbContext.Books.Add(book);
        dbContext.SaveChanges();
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}