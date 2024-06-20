using Application.DTOs;
using Application.Features.Positions.Queries;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Positions.Handlers
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<PositionDto>>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GetPositionsQueryHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<PositionDto>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await context.Positions.ToListAsync(cancellationToken);
            return mapper.Map<IEnumerable<PositionDto>>(positions);
        }
    }
}
