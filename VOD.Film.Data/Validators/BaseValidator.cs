using FluentValidation;

namespace VOD.Film.Data.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
        where T : class
    {
        public BaseValidator() { }
    }
}
