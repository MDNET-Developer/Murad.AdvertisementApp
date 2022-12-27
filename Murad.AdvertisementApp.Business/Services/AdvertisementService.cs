using AutoMapper;
using FluentValidation;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.Common.Enums;
using Murad.AdvertisementApp.DataAccsess.UnitOfWork;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementListDto, AdvertisementUpdateDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper ;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status==true, x => x.CreatedDate, Common.Enums.OrderByType.DESC);
            var mappeddata = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, mappeddata);

        }
    }
}
