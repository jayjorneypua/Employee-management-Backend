using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
