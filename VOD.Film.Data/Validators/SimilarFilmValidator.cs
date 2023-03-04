using FluentValidation;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Validators
{
    public class SimilarFilmValidator : AbstractValidator<SimilarFilmModel>
    {
        public SimilarFilmValidator()
        {
            RuleFor(sf => sf.ParentFilm).NotNull();
        }
    }
}
