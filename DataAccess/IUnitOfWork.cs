using Application.InterfaceRepository;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IAccountRepository AccountRepository { get; }
        public IArticleRepository ArticleRepository { get; }

        Task<int> SaveAsync();
        int Save();
    }
}
