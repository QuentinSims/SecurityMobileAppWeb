using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class IncidentController : Controller
    {
        public IActionResult Incident()
        {
            return View();
        }
    }
}
