using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherMgmt.Data;
using TeacherMgmt.Models;
using System.Linq;

namespace TeacherMgmt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsApiController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;

        public SubjectsApiController(AppDbContext context)
        {
            _dbcontext = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectInfoDto dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Subject data is required." });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = GetModelErrors() });

            try
            {
                var subject = new Subjectinfo
                {
                    SubjectCode = dto.SubjectCode,
                    SubjectName = dto.SubjectName,
                    CreditHours = dto.CreditHours,
                    Department = dto.Department,
                    Batch = dto.Batch,
                    ClassType = dto.ClassType,
                    Faculty = dto.Faculty,
                    HasSubSubjects = dto.HasSubSubjects,
                    SubSubjectCount = dto.SubSubjectCount
                };

                _dbcontext.Subject.Add(subject);
                await _dbcontext.SaveChangesAsync();

                return Ok(new { success = true, id = subject.SubjectId });
            }
            catch (Exception)
            {
                return StatusCode(500, new { success = false, message = "Server error adding subject." });
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] SubjectInfoDto dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Updated subject data is required." });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = GetModelErrors() });

            try
            {
                var subject = await _dbcontext.Subject.FindAsync(id);
                if (subject == null)
                    return NotFound(new { success = false, message = "Subject not found." });

                subject.SubjectCode = dto.SubjectCode;
                subject.SubjectName = dto.SubjectName;
                subject.CreditHours = dto.CreditHours;
                subject.Department = dto.Department;
                subject.Batch = dto.Batch;
                subject.ClassType = dto.ClassType;
                subject.Faculty = dto.Faculty;
                subject.HasSubSubjects = dto.HasSubSubjects;
                subject.SubSubjectCount = dto.SubSubjectCount;

                await _dbcontext.SaveChangesAsync();

                return Ok(new { success = true });
            }
            catch (Exception)
            {
                return StatusCode(500, new { success = false, message = "Server error updating subject." });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                var subject = await _dbcontext.Subject.FindAsync(id);
                if (subject == null)
                    return NotFound(new { success = false, message = "Subject not found." });

                _dbcontext.Subject.Remove(subject);
                await _dbcontext.SaveChangesAsync();

                return Ok(new { success = true });
            }
            catch (Exception)
            {
                return StatusCode(500, new { success = false, message = "Server error deleting subject." });
            }
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _dbcontext.Subject
                .Select(s => new SubjectInfoDto
                {
                    SubjectId = s.SubjectId,
                    SubjectCode = s.SubjectCode,
                    SubjectName = s.SubjectName,
                    CreditHours = s.CreditHours,
                    Department = s.Department,
                    Batch = s.Batch,
                    ClassType = s.ClassType,
                    Faculty = s.Faculty,
                    HasSubSubjects = s.HasSubSubjects,
                    SubSubjectCount = s.SubSubjectCount
                }).ToListAsync();

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var s = await _dbcontext.Subject.FindAsync(id);
            if (s == null)
                return NotFound(new { success = false, message = "Subject not found." });

            var dto = new SubjectInfoDto
            {
                SubjectId = s.SubjectId,
                SubjectCode = s.SubjectCode,
                SubjectName = s.SubjectName,
                CreditHours = s.CreditHours,
                Department = s.Department,
                Batch = s.Batch,
                ClassType = s.ClassType,
                Faculty = s.Faculty,
                HasSubSubjects = s.HasSubSubjects,
                SubSubjectCount = s.SubSubjectCount
            };

            return Ok(dto);
        }

        private object GetModelErrors()
        {
            return ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) });
        }
    }
}
