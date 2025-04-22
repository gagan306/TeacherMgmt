using Microsoft.AspNetCore.Mvc;

namespace TeacherMgmt.Controllers.Admin
{
    public class GetScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
