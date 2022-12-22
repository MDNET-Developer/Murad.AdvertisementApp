﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Murad.AdvertisementApp.Business.ValidationRules;
using Murad.AdvertisementApp.DataAccsess.Context;
using Murad.AdvertisementApp.DataAccsess.UnitOfWork;
using Murad.AdvertisementApp.Dtos.ProvidedServiceDtos;
using System.Runtime.ConstrainedExecution;

namespace Murad.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        //singleton : uygulama ilk ayağa kalktığı anda, servisin tek bir instance’ı oluşturularak memory’de tutulur ve daha sonrasında her servis çağrısında bu instance gönderilir.

        //scoped : her request için tek bir instance yaratılmasını sağlayan lifetime seçeneğidir.request cycle’ı tamamlanana kadar gerçekleşen servis çağrılarında daha önce oluşturulan instance gönderilir.daha sonra yeni bir request başladığında farklı bir instance oluşturulur.


        //transient : her servis çağrısında yeni bir instance oluşturulur.bağlayıcılığı en az olan lifetime seçeneğidir.
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
            });

            var mapperConfugiration = new MapperConfiguration(opt =>
            {
                //opt.addprofile
            });

            var mapper = mapperConfugiration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
        }
    }
}