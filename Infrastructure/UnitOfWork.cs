using Application;
using Application.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRequestDetailRepository _requestDetailRepository;
        private readonly IIssueRepository _issueRepository;
        public UnitOfWork (IRequestDetailRepository requestDetailRepository, IIssueRepository issueRepository)
        {
            _requestDetailRepository = requestDetailRepository;
            _issueRepository = issueRepository;
        }
        public IRequestDetailRepository RequestDetailRepository => _requestDetailRepository;

        public IIssueRepository IssueRepository => _issueRepository;
    }
}
