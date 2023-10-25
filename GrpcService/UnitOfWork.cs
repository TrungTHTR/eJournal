using GrpcService;
using GrpcService.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IIssueRepository _issueRepository;

        public UnitOfWork(IIssueRepository issueRepository, AppDbContext appDbContext)
        {
            _issueRepository = issueRepository;
            _appDbContext = appDbContext;
        }

        public IIssueRepository IssueRepository => _issueRepository;

        public async Task<int> SaveChangeAsync()
        {
           return await _appDbContext.SaveChangesAsync();
        }
    }
}
