using BusinessObject;
using Application.ViewModels.RequestDetailViewModels;
using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.RequestDetailViewModels;

namespace Application.InterfaceService
{
    public interface IRequestDetailService
    {
        Task<List<RequestDetail>> GetByReviewerId(Guid accountId);
        Task<List<RequestDetail>> GetAllRequestDetail();
        Task<bool> CreateRequestDetail(CreateRequestDetailViewModel createRequestDetailViewModel);
        Task<bool> RejectRequest(Guid requestDetailId);
        Task ChangeRequestStatus(Guid id, RequestDetailStatus status);
        Task<RequestDetail> GetRequestDetails(Guid id);
        Task<int> UpdateRequestDetail(RequestDetail requestDetail);
    }
}
