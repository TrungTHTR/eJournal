using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IRequestReviewRepository : IGenericRepository<RequestReview>
    {
        Task<List<RequestReview>> ShowAllRequestReview(Guid ArticleId);
        Task<int> CreateRequestReview(RequestReview requestReview);
        Task<RequestReview> GetRequestReviews(Guid id);
        Task<int> UpdateRequestReview(RequestReview requestReview);
        Guid GetLastSavedId();
    }
}