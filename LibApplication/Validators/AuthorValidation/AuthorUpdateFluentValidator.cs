using FluentValidation;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;

namespace LibruaryAPI.Application.Validators.AuthorValidation
{
    /// <summary>
    /// Валидация обновления автора.
    /// </summary>
    public class AuthorUpdateFluentValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public AuthorUpdateFluentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
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
