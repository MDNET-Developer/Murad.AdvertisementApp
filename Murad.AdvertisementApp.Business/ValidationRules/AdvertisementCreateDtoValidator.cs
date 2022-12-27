using FluentValidation;
using Murad.AdvertisementApp.Dtos;

namespace Murad.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementCreateDtoValidator:AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
