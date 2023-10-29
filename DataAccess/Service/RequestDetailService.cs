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
    }
}
