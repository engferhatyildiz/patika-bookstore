using AutoMapper;
using FluentValidation;
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
public class BooksController(BookStoreDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(context, mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        BookDetailViewModel result;
        try
        {
            GetBookDetailQuery query = new GetBookDetailQuery(context, mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
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
        CreateBookCommand command = new CreateBookCommand(context, mapper);
        try
        {
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
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
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
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
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}