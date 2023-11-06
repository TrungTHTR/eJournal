using Application.InterfaceService;
using Application.ViewModels.RequestReviewViewModel;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RequestReviewService : IRequestReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestReviewService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RequestReview>> GetByArticleId(Guid articleId)
        {
            return await _unitOfWork.RequestReviewRepository.ShowAllRequestReview(articleId);
        }
        public async Task<int> CreateRequestReview(CreateRequestReview requestReview)
        {
            var request= _mapper.Map<RequestReview>(requestReview);
            return await _unitOfWork.RequestReviewRepository.CreateRequestReview(request);
        }
        public async Task<RequestReview> GetRequestReviews(Guid id)
        {
            return await _unitOfWork.RequestReviewRepository.GetRequestReviews(id);
        }
        public async Task<int> UpdateRequestReview(RequestReview requestReview)
        {
            return await _unitOfWork.RequestReviewRepository.UpdateRequestReview(requestReview);
        }

        public async Task<List<RequestReview>> GetAllRequestReview()
        {
            return (List<RequestReview>)await _unitOfWork.RequestReviewRepository.GetAllAsync();
        }

        public Guid GetLastSavedId()
        {
           return _unitOfWork.RequestReviewRepository.GetLastSavedId();
        }
    }
}