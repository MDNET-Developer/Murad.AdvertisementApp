using AutoMapper;
using MD.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Entity;

namespace MD.AdvertisementApp.Business.Mapping.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        }
    }
}
