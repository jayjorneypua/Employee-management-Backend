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
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly AppDbContext context;

        public UpdateDepartmentCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await context.Departments.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Department with Id {request.Id} not found.");

            department.Name = request.Name;
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
