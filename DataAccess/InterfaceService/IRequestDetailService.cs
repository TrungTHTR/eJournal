using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IRequestDetailService
    {
        Task<List<RequestDetail>> GetByReviewerId(Guid accountId);
        Task<List<RequestDetail>> GetAllRequestDetail();
        Task<RequestDetail> GetRequestDetails(Guid id);
        Task<int> UpdateRequestDetail(RequestDetail requestDetail);
    }
}
