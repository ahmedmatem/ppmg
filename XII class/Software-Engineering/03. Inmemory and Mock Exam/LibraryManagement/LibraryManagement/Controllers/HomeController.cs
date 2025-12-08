using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("LibraryManagement app is running. Използвайте проекта за упражнение на Unit тестове с InMemory база и Mock обекти.");
        }
    }
}
