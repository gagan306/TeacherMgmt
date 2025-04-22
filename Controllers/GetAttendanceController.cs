using Microsoft.AspNetCore.Mvc;

namespace TeacherMgmt.Controllers
{
    public class GetAttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
