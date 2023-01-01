using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Common.Enums;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.UI.Extensions;
using Murad.AdvertisementApp.UI.Models;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userValidator = userValidator;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var genderdata = await _genderService.GetAllAsync();
            var model = new UserCreateModel();
            model.Gender = new SelectList(genderdata.Data, "Id", "Definition");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var validationresult =  _userValidator.Validate(model);
            if (validationresult.IsValid)
            {
                var convertToDto = _mapper.Map<AppUserCreateDto>(model);
                var response = await _appUserService.CreateUserWithRole(convertToDto,(int)RoleType.Member);
                return this.ResponseRedirectToAction( response,"Index", "Default");
            }
            else
            {
                foreach (var error in validationresult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    var genderdata = await _genderService.GetAllAsync();
                    model.Gender = new SelectList(genderdata.Data, "Id", "Definition");
           
                }
                return View(model);
            }
           
        }

        public IActionResult SignIn()
        {
            return View();
        }

        }
}
