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

        public IAccountRepository AccountRepository { get; }
        
        private readonly IRequestDetailRepository _requestDetailRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRequestReviewRepository _requestReviewRepository;
        private readonly IAccountSpecializationRepository _accountSpecializationRepository;
        private readonly ISpecializationRepository _specializationRepository;
        public UnitOfWork(AppDbContext appDbContext, IClaimService claimService, ICurrentTime timeService, IAccountRepository accountRepository, 
        IArticleRepository articleRepository, IRequestReviewRepository requestReviewRepository
            ,ICountryRepository countryRepository,IAccountSpecializationRepository accountSpecializationRepository,ISpecializationRepository specializationRepository)
        {
            _appDbContext = appDbContext;
            _claimService = claimService;
            _timeService = timeService;
            AccountRepository = accountRepository;
            _articleRepository = articleRepository;
            _countryRepository = countryRepository;
     
            _requestReviewRepository = requestReviewRepository;
            _accountSpecializationRepository= accountSpecializationRepository;
            _specializationRepository= specializationRepository;
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }

        public async  Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
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
        public IArticleRepository ArticleRepository => _articleRepository;
		    public ICountryRepository CountryRepository => _countryRepository;
        public IRequestReviewRepository RequestReviewRepository => _requestReviewRepository;

        public IAccountSpecializationRepository AccountSpecializationRepository => _accountSpecializationRepository;

        public ISpecializationRepository SpecializationRepository => _specializationRepository;
    }
}
