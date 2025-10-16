using System.ComponentModel.DataAnnotations;

namespace hrms_backend.Models
{
    public class Timesheet
    {
        // Primary Key
        [Key]
        public int TimesheetId { get; set; }                // Unique timesheet record ID

        // Foreign Key
        public int EmployeeId { get; set; }                 // References Employee.EmployeeId

        // Timesheet Details
        public DateTime Date { get; set; }                  // The date of work log
        public decimal HoursWorked { get; set; }            // Hours worked on that day

        // Navigation Property
        public Employee? Employee { get; set; }
    }
}
