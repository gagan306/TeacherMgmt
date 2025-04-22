using Microsoft.AspNetCore.Mvc;

namespace TeacherMgmt.Controllers.Admin
{
    public class ManualSchedulingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
