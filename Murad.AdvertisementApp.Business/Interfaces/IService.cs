using Murad.AdvertisementApp.Common;
using Murad.AdvertisementApp.Dtos.Interfaces;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto,ListDto,UpdateDto,T>
        where CreateDto: class ,IDto,new()
        where ListDto:class,IDto,new()
        where UpdateDto:class,IDto,new()
        where T:BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync(int id);
        Task<IResponse> RemoveAsync(int id);
    }
}
