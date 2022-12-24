using Murad.AdvertisementApp.Dtos.ProvidedServiceDtos;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService:IService<ProvidedServiceCreateDto,ProvidedServiceListDto,ProvidedServiceUpdateDto, ProvidedService>
    {
    }
}
