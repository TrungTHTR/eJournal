using Application.InterfaceService;
using BusinessObject;
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
        public RequestDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RequestDetail>> GetByReviewerId(Guid accountId)
        {
            return await _unitOfWork.RequestDetailRepository.ShowAllRequestDetail(accountId);
        }
        public async Task<List<RequestDetail>> GetAllRequestDetail()
        {
            return await _unitOfWork.RequestDetailRepository.GetAllRequestDetail();
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
