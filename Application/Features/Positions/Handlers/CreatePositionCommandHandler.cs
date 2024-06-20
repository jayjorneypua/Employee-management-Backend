using Application.Features.Positions.Commands;
using Core.Entities;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Positions.Handlers
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, int>
    {
        private readonly AppDbContext context;

        public CreatePositionCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = new Position
            {
                Title = request.Title,
                DepartmentId = request.DepartmentId,
            };

            await context.Positions.AddAsync(position); 
            await context.SaveChangesAsync(cancellationToken);

            return position.Id;
        }
    }
}
