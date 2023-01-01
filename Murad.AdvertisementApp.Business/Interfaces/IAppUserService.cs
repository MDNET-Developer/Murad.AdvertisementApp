using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.Dtos;
using Murad.AdvertisementApp.Dtos.AppUserDtos;
using Murad.AdvertisementApp.Entity;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserListDto, AppUserUpdateDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateUserWithRole(AppUserCreateDto dto, int roleId);
    }
}
