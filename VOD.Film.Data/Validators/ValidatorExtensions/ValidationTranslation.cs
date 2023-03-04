using FluentValidation.Results;
using OneOf;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Validators.ValidatorExtensions
{
    public static class ValidationTranslation
    {
        public static OneOf<ValidationResult, List<string>> Validate<T>(T param)
        {
            ValidationResult result;

            if (param is FilmModel filmModel)
            {
                var validator = new FilmValidator();
                result = validator.Validate(filmModel);

                if (!result.IsValid)
                {
                    var qw = result.Errors.Select(fail => fail.ErrorMessage);
                    return qw.ToList();
                }

            }
            else if (param is Director director)
            {
                var validator = new DirectorValidator();
                result = validator.Validate(director);
                if (!result.IsValid)
                {
                    var qw = result.Errors.Select(fail => fail.ErrorMessage);
                    return qw.ToList();
                }
            }
            else if (param is SimilarFilmModel similarFilm)
            {
                var validator = new SimilarFilmValidator();
                result = validator.Validate(similarFilm);
                if (!result.IsValid)
                {
                    var qw = result.Errors.Select(fail => fail.ErrorMessage);
                    //var ww = qw.ToDictionary(group => "Errors", x => new List<string> { x });
                    return qw.ToList();
                }
            }
            else if (param is Genre Genre)
            {
                var validator = new GenreValidator();
                result = validator.Validate(Genre);
                if (!result.IsValid)
                {
                    var qw = result.Errors.Select(fail => fail.ErrorMessage);
                    return qw.ToList();
                }
            }
            else
            {
                throw new ArgumentException("Type is not supported");
            }

            return result;
        }
    }
}
