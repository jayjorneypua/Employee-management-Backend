﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Positions.Commands
{
    public class UpdatePositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
    }
}
