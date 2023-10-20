using Application.InterfaceRepository;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        int Save();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity: BaseEntity;
    }
}
