using Microsoft.AspNetCore.Http.HttpResults;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.DeleteBook;

public class DeleteBookCommand(BookStoreDbContext dbContext)
{
    public int BookId { get; set; }
    public void Handle()
    {
        var book = dbContext.Books.SingleOrDefault(x => x.Id == BookId);
        if (book is null)
            throw new InvalidOperationException("The book does not found for delete");

        dbContext.Books.Remove(book);
        dbContext.SaveChanges();
    }
}