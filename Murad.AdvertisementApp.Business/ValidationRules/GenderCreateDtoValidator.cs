using FluentValidation;
using MD.AdvertisementApp.Dtos;

namespace MD.AdvertisementApp.Business.ValidationRules
{
    public class GenderCreateDtoValidator:AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
