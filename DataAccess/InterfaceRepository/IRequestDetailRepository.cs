using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IRequestDetailRepository : IGenericRepository<RequestDetail>
    {
        Task<List<RequestDetail>> ShowAllRequestDetail(Guid AccountId);
        Task<List<RequestDetail>> GetAllRequestDetail();
        Task<RequestDetail> GetRequestDetails(Guid id);
        Task<int> UpdateRequestDetail(RequestDetail requestDetail);
    }
}