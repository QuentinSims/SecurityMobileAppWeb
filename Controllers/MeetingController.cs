using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Meeting()
        {
            return View();
        }
    }
}
