using AutoMapper;
using DataAccess.Identity.Model;
using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<RoleDto, AppRole>().ReverseMap();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<UpdateUserDto, AppUser>().ReverseMap();
        }
    }
}
