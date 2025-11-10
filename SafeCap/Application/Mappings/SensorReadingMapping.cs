using AutoMapper;
using SafeCap.Application.DTOs.Request;
using SafeCap.Application.DTOs.Response;
using SafeCap.Domain.Entities;

namespace SafeCap.Application.Mappings
{
    public class SensorReadingMapping : Profile
    {
        public SensorReadingMapping() 
        {
            CreateMap<SensorReading, SensorReadingResponse>();
            CreateMap<SensorReadingResponse, SensorReading>();
            CreateMap<SensorReadingRequest, SensorReading>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
