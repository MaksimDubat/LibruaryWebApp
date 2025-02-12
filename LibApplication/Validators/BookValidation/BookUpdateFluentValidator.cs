﻿using FluentValidation;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;

namespace LibruaryAPI.Application.Validators.BookValidation
{
    /// <summary>
    /// Валидация обновления книг.
    /// </summary>
    public class BookUpdateFluentValidator : AbstractValidator<UpdateBookCommand>
    {
        public BookUpdateFluentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("cant be null");
            RuleFor(x => x.Book.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("no longer than 100");
            RuleFor(x => x.Book.Description)
                .NotEmpty()
                .MaximumLength(250)
                .WithMessage("no longer than 250");
            RuleFor(x => x.Book.Image)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("need image");
            RuleFor(x => x.Book.Amount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("cant be less than 0");
        }
    }
}
