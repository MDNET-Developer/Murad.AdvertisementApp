using AutoMapper;
using FluentValidation;
using Murad.AdvertisementApp.Business.Extensions;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.DataAccsess.UnitOfWork;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Dtos.AppUserDtos;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserListDto, AppUserUpdateDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createAppUserDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createAppUserDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>>CreateUserWithRole(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createAppUserDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var userMapingData = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUser>().Create(userMapingData);

                await _uow.GetRepository<AppUserRole>().Create(new AppUserRole
                {
                    AppUser=userMapingData,
                    AppRoleId=roleId
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

            }
            else
            {
                return new Response<AppUserCreateDto>(ResponseType.ValidationError, validationResult.ConvertDefaultValidationFromCustomValidationError(), dto);
            }
        }
    }
}
