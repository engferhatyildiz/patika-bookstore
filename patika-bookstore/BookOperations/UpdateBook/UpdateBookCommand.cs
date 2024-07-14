using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using patika_bookstore.DBOperations;

namespace patika_bookstore.BookOperations.UpdateBook;

public class UpdateBookCommand(BookStoreDbContext context)
{
    public int BookId { get; set; }
    public UpdateBookModel Model { get; set; }
    public void Handle()
    {
        var book = context.Books.SingleOrDefault(x => x.Id == BookId);

        if (book is null)
            throw new InvalidOperationException("The book does not found for the update operation");

        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.Title = Model.Title != default ? Model.Title : book.Title;

        context.SaveChanges();
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}