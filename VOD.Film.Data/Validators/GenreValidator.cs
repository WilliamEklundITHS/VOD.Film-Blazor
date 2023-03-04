using FluentValidation;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Validators
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(genre => genre.Name).NotEmpty();
            RuleFor(genre => genre.Id).NotEmpty();
        }
    }
}
