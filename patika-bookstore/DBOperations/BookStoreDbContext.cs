using Microsoft.EntityFrameworkCore;

namespace patika_bookstore.DBOperations;

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}