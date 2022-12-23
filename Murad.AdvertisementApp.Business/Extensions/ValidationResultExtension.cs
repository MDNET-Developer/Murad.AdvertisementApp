using FluentValidation.Results;
using Murad.AdvertisementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertDefaultValidationFromCustomValidationError(this FluentValidation.Results.ValidationResult validationResult)
        {
            List<CustomValidationError> customValidationErrors = new List<CustomValidationError>();
            foreach (var item in validationResult.Errors)
            {
                customValidationErrors.Add(new()
                {
                    ErrorMessage=item.ErrorMessage,
                    PropertyName=item.PropertyName
                });
            }

            return customValidationErrors;
        }
    }
}
