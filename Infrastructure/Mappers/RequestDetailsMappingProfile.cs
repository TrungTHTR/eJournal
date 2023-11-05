using Application.ViewModels.RequestReviewViewModels;
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
			CreateMap<CreatedRequestDetailsRequest, RequestDetail>()
				.AfterMap((src, dest) =>
				{
					dest.Description = "";
					dest.Status = ((int) RequestDetailStatus.OnProcess);
					dest.ModificationDate = DateTime.Now;
					dest.CreationDate = DateTime.Now;
					dest.IsDelete = false;
				});
			CreateMap<RequestDetail, RequestDetailResponse>();
		}
	}
}
