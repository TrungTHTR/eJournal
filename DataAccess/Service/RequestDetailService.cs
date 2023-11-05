using Application.InterfaceService;
using Application.ViewModels.RequestDetailViewModel;
using AutoMapper;
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
        private IMapper _mapper;
        public RequestDetailService(IUnitOfWork unitOfWork,IMapper mapper)
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

        public async Task<bool> CreateRequestDetail(CreateRequestDetailViewModel createRequestDetailViewModel)
        {
           var requestDetail = _mapper.Map<RequestDetail>(createRequestDetailViewModel);
            await _unitOfWork.RequestDetailRepository.AddAsync(requestDetail);
            return await _unitOfWork.SaveAsync()>0;
        }

        public async Task<bool> RejectRequest(Guid requestDetailId)
        {
            await _unitOfWork.RequestDetailRepository.SoftRemove(requestDetailId);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
