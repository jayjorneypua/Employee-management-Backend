using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
