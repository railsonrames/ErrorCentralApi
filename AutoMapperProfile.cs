
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using ErrorCentralApi.DTOs;
using ErrorCentralApi.Models;

namespace ErrorCentralApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Error, ErrorDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
    
}