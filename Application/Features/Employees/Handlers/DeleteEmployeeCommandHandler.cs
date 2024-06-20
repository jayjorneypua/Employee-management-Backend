using Application.Features.Employees.Commands;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly AppDbContext context;

        public DeleteEmployeeCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Employee with ID {request.Id} does not exists.");

            context.Employees.Remove(employee); 
            await context.SaveChangesAsync(cancellationToken);  

            return Unit.Value;
        }
    }
}
