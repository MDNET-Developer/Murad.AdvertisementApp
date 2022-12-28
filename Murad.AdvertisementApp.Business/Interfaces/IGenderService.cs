using MD.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Entity;

namespace MD.AdvertisementApp.Business.Interfaces
{
    public interface IGenderService:IService<GenderCreateDto,GenderListDto,GenderUpdateDto,Gender>
    {
    }
}
