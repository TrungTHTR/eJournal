using Application.InterfaceService;
using Application.ViewModels.RequestReviewViewModels;
using AutoMapper;
using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class RequestDetailService : IRequestDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RequestDetail>> GetByReviewerId(Guid accountId)
        {
            return await _unitOfWork.RequestDetailRepository.ShowAllRequestDetail(accountId);
        }
        public async Task<List<RequestDetail>> GetAllRequestDetail()
        {
            return await _unitOfWork.RequestDetailRepository.GetAllRequestDetail();
        }

		public async Task ChangeRequestStatus(Guid id, RequestDetailStatus status)
		{
            var requestDetail = await _unitOfWork.RequestDetailRepository.GetAsync(id);
            if (requestDetail == null)
            {
                throw new Exception("Request details doesn't exist");
            }
            requestDetail.Status = ((int)status);
            _unitOfWork.RequestDetailRepository.Update(requestDetail);
            await _unitOfWork.SaveAsync();
		}

		public async Task Create(CreatedRequestDetailsRequest request)
		{
            var detail = _mapper.Map<RequestDetail>(request);
            await _unitOfWork.RequestDetailRepository.AddAsync(detail);
            await _unitOfWork.SaveAsync();
		}
        public async Task<RequestDetail> GetRequestDetails(Guid id)
        {
            return await _unitOfWork.RequestDetailRepository.GetRequestDetails(id);
        }
        public async Task<int> UpdateRequestDetail(RequestDetail requestDetail)
        {
            return await _unitOfWork.RequestDetailRepository.UpdateRequestDetail(requestDetail);
        }
    }
}
