using FluentValidation;
using Murad.AdvertisementApp.Dtos.ProvidedServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServiceCreateDtoValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
