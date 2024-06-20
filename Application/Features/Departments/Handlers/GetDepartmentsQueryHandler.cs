using Application.DTOs;
using Application.Features.Departments.Queries;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Handlers
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GetDepartmentsQueryHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await context.Departments.ToListAsync(cancellationToken);
            return mapper.Map<IEnumerable<DepartmentDto>>(departments); 
        }
    }
}
