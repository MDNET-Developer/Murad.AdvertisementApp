using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.Common;
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
        where UpdateDto : class, IDto, new()
        where T : BaseEntity
    {
        public Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
