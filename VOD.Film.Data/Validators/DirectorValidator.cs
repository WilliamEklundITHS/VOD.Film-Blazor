using FluentValidation;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Validators
{
    public class DirectorValidator : AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(sf => sf).NotNull();
            RuleFor(sf => sf.Name).NotEmpty();
            RuleFor(sf => sf.Id).NotEmpty();
        }
    }
}
