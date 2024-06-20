using Application.Features.Departments.Commands;
using Core.Entities;
using Infrastructure.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Departments.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Name
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return department.Id;
        }
    }
}
