using Microsoft.AspNetCore.Mvc;
using SecurityMobileAppWeb.Services.Incidents;

namespace SecurityMobileAppWeb.Controllers
{
    public class IncidentController : Controller
    {
        readonly IIncident _incident;
        public IncidentController(IIncident incident)
        {
            _incident = incident;
        }
        public IActionResult Incident()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
