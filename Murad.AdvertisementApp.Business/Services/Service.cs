using AutoMapper;
using FluentValidation;
using Murad.AdvertisementApp.Business.Extensions;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.DataAccsess.UnitOfWork;
using Murad.AdvertisementApp.Dtos.Interfaces;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, ListDto, UpdateDto, T> : IService<CreateDto, ListDto, UpdateDto, T>
        where CreateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var validationresult = _createDtoValidator.Validate(dto);
            if (validationresult.IsValid)
            {
                var mapped = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().Create(mapped);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success,dto);
            }
            return new Response<CreateDto>(ResponseType.ValidationError, validationresult.ConvertDefaultValidationFromCustomValidationError(),dto);
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var defaultdata = await _uow.GetRepository<T>().GetAllAsync();
            var mappeddata =  _mapper.Map<List<ListDto>>(defaultdata);
            return new Response<List<ListDto>>(ResponseType.Success, mappeddata);
        }

        public async Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            var defaultdata = await _uow.GetRepository<T>().GetByFilter(x => x.Id == id);
            if (defaultdata == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}-li data tapılmadı");
            }
            var mappeddata = _mapper.Map<IDto>(defaultdata);
            return new Response<IDto>(ResponseType.Success, mappeddata);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var dataid = await _uow.GetRepository<T>().Find(id);
            if (dataid == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}-li data tapılmadı");
            }
            _uow.GetRepository<T>().Remove(dataid);
            await _uow.SaveChangesAsync();
            return new Response<IDto>(ResponseType.Success, $"{id}-li data uğurla silindi");
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var resultvalidation = _updateDtoValidator.Validate(dto);
            if(resultvalidation.IsValid)
            {
                var unchangeddata = await _uow.GetRepository<T>().Find(dto.Id);
                var mappeddata = _mapper.Map<T>(dto);
                 _uow.GetRepository<T>().Update(mappeddata, unchangeddata);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<UpdateDto>(ResponseType.ValidationError, resultvalidation.ConvertDefaultValidationFromCustomValidationError(), dto);
            }

        }
    }
}
