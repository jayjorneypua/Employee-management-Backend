using Application.Features.Departments.Commands;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly AppDbContext context;

        public DeleteDepartmentCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await context.Departments.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Department with Id {request.Id} not found.");

            context.Departments.Remove(department);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
