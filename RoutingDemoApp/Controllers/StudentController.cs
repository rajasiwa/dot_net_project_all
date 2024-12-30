using Microsoft.AspNetCore.Mvc;

namespace RoutingDemoApp.Controllers
{
    public class StudentController : Controller
    {
        // Action for Index (Home Page)
        public IActionResult Index()
        {
            return View();
        }

        // Action for About Page
        public IActionResult About()
        {
            ViewBag.Message = "This is the About page for Students.";
            return View();
        }

        // Action for Details Page
        public IActionResult Details(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }
    }
}
