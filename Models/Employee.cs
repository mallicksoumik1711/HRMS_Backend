using System.ComponentModel.DataAnnotations;

namespace hrms_backend.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }                // Unique employee ID
        public string Name { get; set; }                   // Employee name
        public string Email { get; set; }                  // Employee email
        public string Department { get; set; }             // Department name
        public string Password { get; set; }               // Hashed password

        // Hierarchy
        public int? ManagerId { get; set; }                // Employee ID of manager (nullable)
        public List<int>? MyJuniors { get; set; }          // List of employee IDs who report to this employee

        // Role & Permissions
        public bool IsAdmin { get; set; } = false;         // True if HR/admin user

        // Leave Data
        public int TotalLeaves { get; set; } = 18;         // Same for all employees (default yearly quota)
        public int LeavesRemaining { get; set; }           // Dynamic: updated when leaves are approved/cancelled
        public int LeavesTaken { get; set; }               // Dynamic: total leaves taken (computed)

        // Navigation Data
        public List<Leave>? Leaves { get; set; }           // All leave records for this employee
        public List<Timesheet>? Timesheets { get; set; }   // All timesheet entries for this employee
    }
}
