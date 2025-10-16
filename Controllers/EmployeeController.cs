using hrms_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hrms_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployee = _context.employees.ToList();
            return Ok(allEmployee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Models.Employee newEmployee)
        {
            _context.employees.Add(newEmployee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.EmployeeId }, newEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Models.Employee updatedEmployee)
        {
            var existingEmployee = _context.employees.Find(id);
            if (existingEmployee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            // Update fields
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Password = updatedEmployee.Password;
            existingEmployee.ManagerId = updatedEmployee.ManagerId;
            existingEmployee.MyJuniors = updatedEmployee.MyJuniors;
            existingEmployee.IsAdmin = updatedEmployee.IsAdmin;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            _context.employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
