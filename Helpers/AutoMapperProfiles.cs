using AutoMapper;
using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using KeerthiveeduAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace KeerthiveeduAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(d => d.FamilyGroupName, o => o.MapFrom(s => s.FamilyGroup.Name))
                .ForMember(d=>d.Age,o=>o.MapFrom(s=>s.DateOfBirth.CalculateAge()));
            CreateMap<Committee, CommitteeDto>();
        }
    }
}
