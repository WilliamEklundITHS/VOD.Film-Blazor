using FluentValidation;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Validators
{
    public class FilmValidator : BaseValidator<FilmModel>
    {
        public FilmValidator()
        {
            RuleFor(film => film.Director).NotNull();
            RuleFor(film => film.FilmGenres).NotEmpty();
            RuleFor(film => film.Title).NotEmpty().MaximumLength(50);
            RuleFor(film => film.Description).NotEmpty().MaximumLength(200);
            RuleFor(film => film.FilmUrl).MaximumLength(1024);
            RuleFor(film => film.FilmPosterUrl).MaximumLength(1024);
        }
    }
}
