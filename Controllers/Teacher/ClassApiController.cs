using Microsoft.AspNetCore.Mvc;
using TeacherMgmt.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TeacherMgmt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassApiController : ControllerBase
    {
        private readonly Data.AppDbContext _dbcontext;

        public ClassApiController(Data.AppDbContext context)
        {
            _dbcontext = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddClass([FromBody] ClassInfo model)
        {
            if (model == null)
                return BadRequest(new { success = false, message = "Class data is required." });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = GetModelErrors() });

            try
            {
                _dbcontext.ClassInfo.Add(model);
                await _dbcontext.SaveChangesAsync();

                return Ok(new { success = true, id = model.ClassId });
            }
            catch (Exception ex)
            {
                // Log ex here
                return StatusCode(500, new { success = false, message = "Server error adding class." });
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] ClassInfo updated)
        {
            if (updated == null)
                return BadRequest(new { success = false, message = "Updated class data is required." });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = GetModelErrors() });

            try
            {
                var existing = await _dbcontext.ClassInfo.FindAsync(id);
                if (existing == null)
                    return NotFound(new { success = false, message = "Class not found." });

                existing.ClassName = updated.ClassName;
                existing.Faculty = updated.Faculty;
                existing.Shift = updated.Shift;
                existing.Duration = updated.Duration;
                existing.BreakDuration = updated.BreakDuration;
                existing.Batch = updated.Batch;
                existing.TimeFrom = updated.TimeFrom;
                existing.TimeTo = updated.TimeTo;

                await _dbcontext.SaveChangesAsync();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                // Log ex here
                return StatusCode(500, new { success = false, message = "Server error updating class." });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                var existing = await _dbcontext.ClassInfo.FindAsync(id);
                if (existing == null)
                    return NotFound(new { success = false, message = "Class not found." });

                _dbcontext.ClassInfo.Remove(existing);
                await _dbcontext.SaveChangesAsync();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                // Log ex here
                return StatusCode(500, new { success = false, message = "Server error deleting class." });
            }
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllClasses()
        {
            var list = await _dbcontext.ClassInfo.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var data = await _dbcontext.ClassInfo.FindAsync(id);
            if (data == null)
                return NotFound(new { success = false, message = "Class not found." });

            return Ok(data);
        }

        private object GetModelErrors()
        {
            return ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) });
        }
    }
}
