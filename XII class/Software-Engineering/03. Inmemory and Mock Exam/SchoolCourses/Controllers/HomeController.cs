using Microsoft.AspNetCore.Mvc;

namespace SchoolCourses.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("SchoolCourses app is running. Use this project to practice unit tests with EF Core InMemory and mocks.");
        }
    }
}
