using Application.ViewModels.RequestReviewViewModel;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
	public  class RequestReviewMappingProfile:Profile
	{
		public RequestReviewMappingProfile() 
		{
			CreateMap<CreateRequestReview, RequestReview>().ReverseMap();
		}
	}
}
