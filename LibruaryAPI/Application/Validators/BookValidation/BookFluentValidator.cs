using FluentValidation;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;

namespace LibruaryAPI.Application.Validators.BookValidation
{
    /// <summary>
    /// Валидация книг.
    /// </summary>
    public class BookFluentValidator : AbstractValidator<AddBookCommand>
    {
        public BookFluentValidator()
        {
            RuleFor(x => x.Book)
                .NotNull()
                .WithMessage("cant be null");
            RuleFor(x => x.Book.BookId)
                .NotEmpty()
                .WithMessage("need Id");
            RuleFor(x => x.Book.ISBN)
                .NotEmpty()
                .WithMessage("error generation of ISBN");
            RuleFor(x => x.Book.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("no longer than 100");
            RuleFor(x => x.Book.Description)
                .NotEmpty()
                .MaximumLength(250)
                .WithMessage("no longer than 250");
            RuleFor(x => x.Book.Author)
                .NotEmpty()
                .WithMessage("need author");
            RuleFor(x => x.Book.AuthorId)
                .NotEmpty()
                .WithMessage("need authorId");
            RuleFor(x => x.Book.Amount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("cant be less than 0");
        }
    }
}
