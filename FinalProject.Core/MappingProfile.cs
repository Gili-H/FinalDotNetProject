using AutoMapper;
using FinalProject.Core.DTOs;
using FinalProjectNetCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Admin,AdminDto>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestDto>().ReverseMap();
            CreateMap<WorkLog,WorkLogDto>().ReverseMap();

        }


    }
}
