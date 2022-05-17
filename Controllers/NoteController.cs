using Microsoft.AspNetCore.Mvc;

namespace SecurityMobileAppWeb.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Note()
        {
            return View();
        }
        public IActionResult Add()
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
