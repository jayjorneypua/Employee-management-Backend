using Application.DTOs;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().
                ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
               .ForMember(dest => dest.PositionTitle, opt => opt.MapFrom(src => src.Position.Title))
               .ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
        }
    }
}
