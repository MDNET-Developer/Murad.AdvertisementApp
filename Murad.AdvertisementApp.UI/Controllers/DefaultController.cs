using Microsoft.AspNetCore.Mvc;
using Murad.AdvertisementApp.Business.Interfaces;
using Murad.AdvertisementApp.UI.Extensions;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;

        public DefaultController(IProvidedServiceService providedServiceService)
        {
            _providedServiceService = providedServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var dataresult = await _providedServiceService.GetAllAsync();
            return this.ResponseView(dataresult);
        }
    }
}
