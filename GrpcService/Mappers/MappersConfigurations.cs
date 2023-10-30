using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcService.issueCRUD;
using BusinessObject;
using Azure.Core;
using System.Globalization;
using Guid = System.Guid;

namespace GrpcService.Mappers
{
    public class MappersConfigurations:Profile
    {
        public MappersConfigurations()
        {
            CreateMap<AddIssue,Issue>()
                 .ForMember(dest => dest.DateRelease, opt => opt.MapFrom(src => ParseStringToDateTime(src.DateRelease)))
                .ReverseMap();
            CreateMap<ModifyIssue,Issue>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ParseStringToGuid(src.Id)))
                .ForMember(dest => dest.DateRelease, opt => opt.MapFrom(src => ParseStringToDateTime(src.DateRelease)))
                .ReverseMap();
            
        }
        private DateTime ParseStringToDateTime(string dateString)
        {
            DateTime result;
            // Parse the string to DateTime using a specific format 
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            // Handle parsing errors here if needed
            throw new Exception("Invalid date format");
        }
        private Guid ParseStringToGuid(string id)
        {
            Guid result;
            if (Guid.TryParse(id, out result))
            {
                return result;
            }
            throw new Exception("Invalid date format");
        }
    }
}
