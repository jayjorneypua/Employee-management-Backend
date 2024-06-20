using MediatR;

namespace Application.Features.Departments.Commands
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
