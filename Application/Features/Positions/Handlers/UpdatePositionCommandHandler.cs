using Application.Features.Positions.Commands;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Positions.Handlers
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Unit>
    {
        private readonly AppDbContext context;

        public UpdatePositionCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await context.Positions.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Position with Id {request.Id} not found.");

            position.Title = request.Title;
            position.DepartmentId = request.DepartmentId;
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
