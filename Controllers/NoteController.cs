using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Note()
        {
            return View();
        }
    }
}
