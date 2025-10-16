using hrms_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hrms_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllLeaves()
        {
            var allLeaves = _context.leaves.ToList();
            return Ok(allLeaves);
        }

        [HttpGet("{id}")]
        public IActionResult GetLeaveById(int id)
        {
            var leave = _context.leaves.Find(id);
            if (leave == null)
            {
                return NotFound(new { message = "Leave record not found" });
            }
            return Ok(leave);
        }

        [HttpPost]
        public IActionResult CreateLeave([FromBody] Models.Leave newLeave)
        {
            _context.leaves.Add(newLeave);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLeaveById), new { id = newLeave.LeaveId }, newLeave);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLeave(int id, [FromBody] Models.Leave updatedLeave)
        {
            var existingLeave = _context.leaves.Find(id);
            if (existingLeave == null)
            {
                return NotFound(new { message = "Leave record not found" });
            }
            // Update fields
            existingLeave.Title = updatedLeave.Title;
            existingLeave.FromDate = updatedLeave.FromDate;
            existingLeave.ToDate = updatedLeave.ToDate;
            existingLeave.Reason = updatedLeave.Reason;
            existingLeave.Description = updatedLeave.Description;
            existingLeave.Status = updatedLeave.Status;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLeave(int id)
        {
            var existingLeave = _context.leaves.Find(id);
            if (existingLeave == null)
            {
                return NotFound(new { message = "Leave record not found" });
            }
            _context.leaves.Remove(existingLeave);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
