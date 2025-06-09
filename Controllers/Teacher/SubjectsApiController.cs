using Microsoft.AspNetCore.Mvc;

namespace TeacherMgmt.Controllers.Teacher
{
   
    
        [ApiController]
        [Route("api/[controller]")]
        public class SubjectsApiController : ControllerBase
        {
            [HttpPost]
            public IActionResult AddSubject([FromBody] SubjectModel subject)
            {
                if (subject == null)
                    return BadRequest("Subject data is null.");

                // You can log this or break here to debug in real-time
                Console.WriteLine($"Received subject: {subject.SubjectCode} - {subject.SubjectName}");

                return Ok(new { message = "Subject received successfully" });
            }
        }
    public class SubjectModel
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string CreditHours { get; set; }
        public string Department { get; set; }
        public string ClassType { get; set; }
    }
}

