using Microsoft.AspNetCore.Mvc;
using Murad.AdvertisementApp.Common;

namespace Murad.AdvertisementApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        //Misal ucun insert sehifesine daixil olub verileni post edirik daha sonra geriye umumen table-da data-larin list oldugu sehifeye getmek isteyende RedirectToAction olub diger sehifeye kecid edirik. Bu zaman datanin kecidi bas verir ki verileni bazaya post edirik. Bunu eden zaman qarsimiza 3 hall cixa biler.Birinci hall NotFound, ikinci hall ValidationError, ucuncu hallda ise ugurlu olaraq diger sehifeye kecid edecek.
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName,string controllerName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.Errors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName, controllerName);
        }
        //-------------------------------------------------------------------------------------------------
        //GetById metoduna benzeyir
        //Geriye basqa bir action dondermir deyene action name ehtiyac yoxdur burada. return View(); metodu benzeri sistemdir bir nov
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.View(response.Data);
        }

        //Delete olan zaman geriye donen zaman istifade olunan metoda benzeyir
        //silme zamani geriya artiq data dasimiriq
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName,string controllerName)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.RedirectToAction(actionName,controllerName);
        }
    }
}
