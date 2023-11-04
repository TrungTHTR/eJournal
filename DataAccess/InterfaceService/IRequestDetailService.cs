using Application.ViewModels.RequestReviewViewModels;
using BusinessObject;
using BusinessObject.Enums;
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
        Task ChangeRequestStatus(Guid id, RequestDetailStatus status);
        Task Create(CreatedRequestDetailsRequest request);
    }
}
