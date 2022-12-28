using AutoMapper;
using MD.AdvertisementApp.Business.Mapping.AutoMapper;
using Murad.AdvertisementApp.Business.Mapping.AutoMapper;
using System.Collections.Generic;

namespace Murad.AdvertisementApp.Business.Helper
{
    public static class MapProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
               new ProvidedServiceProfile(),
               new AdvertisementProfile(),
               new AppUserProfile(),
               new GenderProfile()
            };
        }
    }
}
