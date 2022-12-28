using AutoMapper;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.UI.Models;

namespace MD.AdvertisementApp.UI.AutoMapper
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
