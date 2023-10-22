using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcService.issueCRUD;
using BusinessObject;
namespace GrpcService.Mappers
{
    public class MappersConfigurations:Profile
    {
        public MappersConfigurations()
        {
            CreateMap<Google.Protobuf.WellKnownTypes.Timestamp, DateTime>()
                   .ConvertUsing(timestamp => timestamp.ToDateTime());
            CreateMap<DateTime, Google.Protobuf.WellKnownTypes.Timestamp>()
                   .ConvertUsing(dateTime => Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(dateTime));
            CreateMap<AddIssue,Issue>()
                .ForMember(dest=>dest.DateRelease,opt=>opt.MapFrom(src=>src.DateRelease))
                .ReverseMap();
            CreateMap<ModifyIssue,Issue>()
                .ForMember(dest => dest.DateRelease, opt => opt.MapFrom(src => src.DateRelease))
                .ReverseMap();
            
        }
    }
}
