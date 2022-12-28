using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Dtos.AppUserDtos;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserListDto, AppUserUpdateDto, AppUser>
    {
    }
}
