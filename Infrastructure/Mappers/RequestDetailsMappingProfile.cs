using Application.ViewModels.RequestDetailViewModels;
using AutoMapper;
using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class RequestDetailsMappingProfile: Profile
	{
		public RequestDetailsMappingProfile()
		{
			CreateMap<CreateRequestDetailViewModel, RequestDetail>()
				.AfterMap((src, dest) =>
				{
					dest.Description = "";
					dest.Status = ((int) RequestDetailStatus.OnProcess);
					dest.ModificationDate = DateTime.Now;
					dest.CreationDate = DateTime.Now;
					dest.IsDelete = false;
				}).ForMember(dest=>dest.RequestId,opt=>opt.MapFrom(src=>src.RequestId));
			CreateMap<RequestDetail, RequestDetailResponse>();
		}
	}
}
