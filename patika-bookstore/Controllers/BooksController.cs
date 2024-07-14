using Microsoft.AspNetCore.Mvc;
using patika_bookstore.BookOperations.CreateBook;
using patika_bookstore.BookOperations.DeleteBook;
using patika_bookstore.BookOperations.GetBookDetail;
using patika_bookstore.BookOperations.GetBooks;
using patika_bookstore.BookOperations.UpdateBook;
using patika_bookstore.DBOperations;
using static patika_bookstore.BookOperations.GetBookDetail.GetBookDetailQuery;
using static patika_bookstore.BookOperations.UpdateBook.UpdateBookCommand;

namespace patika_bookstore.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(BookStoreDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(context);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        BookDetailViewModel result;
        try
        {
            GetBookDetailQuery query = new GetBookDetailQuery(context);
            query.BookId = id;
            result = query.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookCommand.CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(context);
        try
        {
            command.Model = newBook;
            command.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
    {
        try
        {
            UpdateBookCommand command = new UpdateBookCommand(context);
            command.BookId = id;
            command.Model = updateBook;
            command.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        try
        {
            DeleteBookCommand command = new DeleteBookCommand(context);
            command.BookId = id;
            command.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}