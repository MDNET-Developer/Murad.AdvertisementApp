using Microsoft.AspNetCore.Mvc;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.UI.Extensions;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public DefaultController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var dataresult = await _providedServiceService.GetAllAsync();
            return this.ResponseView(dataresult);
        }

        public async Task<IActionResult> HR()
        {
            var advertisementdata = await _advertisementService.GetActiveAsync();
            return this.ResponseView(advertisementdata);
        }
    }
}
