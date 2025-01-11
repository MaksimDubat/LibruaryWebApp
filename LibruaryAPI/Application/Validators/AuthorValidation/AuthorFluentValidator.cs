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
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("no longer than 50");
            RuleFor(x => x.BirthDate)
                .NotEmpty();
        }
    }
}
