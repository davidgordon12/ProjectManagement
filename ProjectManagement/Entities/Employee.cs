using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [RegularExpression(@"^[A-z][A-z][A-z]-[0-9][0-9][0-9][0-9][0-9][0-9]", 
            ErrorMessage = "Please enter a valid Employee number. (e.g ABC-123456)")]
        public string? EmployeeNumber { get; set; }

        [Required(ErrorMessage = "Please enter Employee's first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Employee's last name")]
        public string? LastName { get; set; }

        public string? FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        // FK:
        public int? ProjectId { get; set; }

        // And nav prop:
        public Project? Project { get; set; }
    }
}
