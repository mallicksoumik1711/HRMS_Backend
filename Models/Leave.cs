using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hrms_backend.Models
{
    public class Leave
    {
        // Primary Key
        [Key]
        public int LeaveId { get; set; }                    // Unique leave record ID

        // Foreign Key
        public int EmployeeId { get; set; }                 // References Employee.EmployeeId

        // Leave Details
        public string Title { get; set; }                   // e.g. "Annual Leave"
        public DateOnly FromDate { get; set; }              // Leave start date
        public DateOnly ToDate { get; set; }                // Leave end date
        public string Reason { get; set; }                  // Short reason, e.g. "Vacation"
        public string? Description { get; set; }            // Optional detailed description

        // Status
        public string Status { get; set; } = "Pending";     // Dynamic: updated by manager or HR

        // Navigation Property
        [JsonIgnore]
        public Employee? Employee { get; set; }             // Link back to Employee
    }
}
