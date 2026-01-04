using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EHostels.Application.DTOs;
using EHostels.Data.Models;

namespace EHostels.Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap()
                .ForMember(dest => dest.EntityId, opt => opt.Ignore());
        }
    }
}
