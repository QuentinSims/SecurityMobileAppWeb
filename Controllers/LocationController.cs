using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Location()
        {
            return View();
        }
    }
}
