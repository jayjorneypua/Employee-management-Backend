﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Positions.Queries
{
    public class GetPositionsQuery : IRequest<IEnumerable<PositionDto>>
    {
    }
}
