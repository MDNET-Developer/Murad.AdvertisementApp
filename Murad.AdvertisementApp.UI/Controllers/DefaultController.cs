using Microsoft.AspNetCore.Mvc;
using Murad.AdvertisementApp.Business.Interfaces;

namespace Murad.AdvertisementApp.UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;

        public DefaultController(IProvidedServiceService providedServiceService)
        {
            _providedServiceService = providedServiceService;
        }

        public IActionResult Index()
        {
            var dataresult = _providedServiceService.GetAllAsync();
            return View();
        }
    }
}
