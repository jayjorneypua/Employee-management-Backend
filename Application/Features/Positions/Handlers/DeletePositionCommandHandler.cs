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
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Unit>
    {
        private readonly AppDbContext context;

        public DeletePositionCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await context.Positions.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Position with Id {request.Id} not found.");
            context.Positions.Remove(position);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
