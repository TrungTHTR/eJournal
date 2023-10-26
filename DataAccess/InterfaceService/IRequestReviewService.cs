using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IRequestReviewService
    {
        Task<List<RequestReview>> GetByArticleId(Guid articleId);
        Task<int> CreateRequestReview(RequestReview requestReview);
    }
}
