using AutoMapper;
using SafeCap.Application.DTOs.Response;
using SafeCap.Application.DTOs.Request;
using SafeCap.Domain.Entities;

namespace SafeCap.Application.Mappings
{
    public class AlertMapping : Profile
    {
        public AlertMapping() 
        {
            CreateMap<Alert, AlertResponse>();
            CreateMap<AlertResponse, Alert>();
            CreateMap<AlertRequest, Alert>()
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
