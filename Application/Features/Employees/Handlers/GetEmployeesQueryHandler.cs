using Application.DTOs;
using Application.Features.Employees.Queries;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GetEmployeesQueryHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await context.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
