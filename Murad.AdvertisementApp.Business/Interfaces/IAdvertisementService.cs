using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService:IService<AdvertisementCreateDto,AdvertisementListDto,AdvertisementUpdateDto,Advertisement> 
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync();
    }
}
