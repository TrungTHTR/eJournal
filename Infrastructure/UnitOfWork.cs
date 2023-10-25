using Application;
using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbContextTransaction? _transaction;
        private bool _disposed;
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _timeService;
        private static readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IAccountRepository AccountRepository { get; }
        public IArticleRepository ArticleRepository { get; }
        
        private readonly IRequestDetailRepository _requestDetailRepository;
        private readonly IIssueRepository _issueRepository;
        private readonly IArticleRepository _articleRepository;
        
        public UnitOfWork (IRequestDetailRepository requestDetailRepository, IIssueRepository issueRepository, IArticleRepository articleRepository)
        {
            _requestDetailRepository = requestDetailRepository;
            _issueRepository = issueRepository;
            _articleRepository = articleRepository;
        }
        
        public UnitOfWork(AppDbContext appDbContext, IClaimService claimService, ICurrentTime timeService, IAccountRepository accountRepository, IArticleRepository articleRepository)
        {
            _appDbContext = appDbContext;
            _claimService = claimService;
            _timeService = timeService;
            AccountRepository = accountRepository;
            ArticleRepository = articleRepository;
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            await _appDbContext.DisposeAsync();
        }
        public IRequestDetailRepository RequestDetailRepository => _requestDetailRepository;
        public IIssueRepository IssueRepository => _issueRepository;
        public IArticleRepository ArticleRepository => _articleRepository;
    }
}
