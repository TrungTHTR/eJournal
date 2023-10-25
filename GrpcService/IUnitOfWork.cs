using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcService.InterfaceRepository;
namespace GrpcService
{
    public interface IUnitOfWork
    {
        public IIssueRepository IssueRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
