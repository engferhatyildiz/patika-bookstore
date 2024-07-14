using FluentValidation;

namespace patika_bookstore.BookOperations.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.PageCount).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(3);
        
    }
}