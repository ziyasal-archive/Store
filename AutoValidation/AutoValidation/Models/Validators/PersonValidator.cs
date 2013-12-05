using FluentValidation;

namespace AutoValidation.Models.Validators {
    public class PersonValidator : AbstractValidator<Person> {
        public PersonValidator() {
            RuleFor(x => x.FirstName).Length(3, 20).WithMessage("İsim alanı en az 3, en çok 20 harften oluşabilir");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url alanı boş bırakılamaz");
        }
    }
}