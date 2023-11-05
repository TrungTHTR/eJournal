using Application.ViewModels.RequestDetailViewModel;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public  class RequestDetailMappingProfile:Profile
    {
        public RequestDetailMappingProfile() 
        { 
            CreateMap<CreateRequestDetailViewModel,RequestDetail>().ReverseMap();
        }
    }
}
