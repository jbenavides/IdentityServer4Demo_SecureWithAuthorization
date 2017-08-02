using Microsoft.AspNetCore.Mvc;

namespace ConfArchWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
