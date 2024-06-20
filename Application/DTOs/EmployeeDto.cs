using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int PositionId { get; set; }
        public string PositionTitle { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string ProfilePicturePath { get; set; } // This can be used for returning the file path in responses
    }
}
