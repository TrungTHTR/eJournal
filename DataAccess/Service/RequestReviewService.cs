using Application.InterfaceService;
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
        public RequestReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RequestReview>> GetByArticleId(Guid articleId)
        {
            return await _unitOfWork.RequestReviewRepository.ShowAllRequestReview(articleId);
        }
        public async Task<int> CreateRequestReview(RequestReview requestReview)
        {
            return await _unitOfWork.RequestReviewRepository.CreateRequestReview(requestReview);
        }
    }
}
