using FluentValidation;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;

namespace LibruaryAPI.Application.Validators.AuthorValidation
{
    /// <summary>
    /// Валидация автора.
    /// </summary>
    public class AuthorFluentValidator : AbstractValidator<AddAuthorCommand>
    {
        public AuthorFluentValidator()
        {
            RuleFor(x => x.Author.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.Author.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.Author.Country)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.Author.BirthDate)
                .NotEmpty();
        }
    }
}
