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
        private readonly IArticleRepository _articleRepository;
        private readonly IRequestReviewRepository _requestReviewRepository;
        public UnitOfWork (IRequestDetailRepository requestDetailRepository, IIssueRepository issueRepository, IArticleRepository articleRepository, IRequestReviewRepository requestReviewRepository)
        {
            _requestDetailRepository = requestDetailRepository;
            _issueRepository = issueRepository;
            _articleRepository = articleRepository;
            _requestReviewRepository = requestReviewRepository;
        }
        public IRequestDetailRepository RequestDetailRepository => _requestDetailRepository;
        public IIssueRepository IssueRepository => _issueRepository;
        public IArticleRepository ArticleRepository => _articleRepository;
        public IRequestReviewRepository RequestReviewRepository => _requestReviewRepository;
    }
}
