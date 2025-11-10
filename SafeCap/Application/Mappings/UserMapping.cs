using AutoMapper;
using SafeCap.Domain.Entities;
using SafeCap.Application.DTOs.Response;
using SafeCap.Application.DTOs.Request;

namespace SafeCap.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping() 
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<UserRequest, User>();
        }
    }
}
