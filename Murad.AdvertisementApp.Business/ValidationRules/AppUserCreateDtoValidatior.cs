using FluentValidation;
using Murad.AdvertisementApp.Dtos;

namespace Murad.AdvertisementApp.Business.ValidationRules
{
    public class AppUserCreateDtoValidatior:AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidatior()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
