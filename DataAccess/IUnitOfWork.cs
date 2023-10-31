using Application.InterfaceRepository;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.InterfaceRepository;
namespace Application
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IAccountRepository AccountRepository { get; }
        public IArticleRepository ArticleRepository { get; }
        Task<int> SaveAsync();
        int Save();       
        public IRequestDetailRepository RequestDetailRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IRequestReviewRepository RequestReviewRepository { get; }
        public IMajorRepository MajorRepository { get; }
        //public IIssueRepository IssueRepository { get; }
    }
}
