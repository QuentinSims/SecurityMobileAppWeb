using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Team()
        {
            return View();
        }
    }
}
