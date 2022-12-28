using FluentValidation;
using Murad.AdvertisementApp.UI.Models;

namespace Murad.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrəni daxil edin !!!");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifrə min 8 simvol ola bilər"); ;
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Təkrar şifrə uyğun deyil !!!");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("İstifadəçi adı min 5 simvol ola bilər"); ;
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyyəti seçin "); ;
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınızı daxil edin"); ;
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyadınızı daxil edin");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adını daxil edin");
            RuleFor(x => new { x.UserName, x.FirstName }).Must(x => NotContain(x.UserName, x.FirstName)).WithMessage("İstifadəçi adı ilə adınız eyni ola bilməz !!!").When(x => x.UserName != null && x.FirstName != null);
        }

        private bool NotContain(string UserName, string FirstName)
        {
            return !UserName.Contains(FirstName);
        }
    }
    }

