using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _timeService;
        public GenericRepository(AppDbContext dbContext,IClaimService claimService, ICurrentTime currentTime)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            _claimService = claimService;
            _timeService = currentTime;
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreationDate = _timeService.GetCurrentTime();
            entity.CreatedBy = _claimService.GetCurrentUserId;
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async  Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
            .Aggregate(_dbSet.AsQueryable(),
                (entity, property) => entity.Include(property))
            .Where(expression).Where(x => x.IsDelete == false).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
           .Aggregate(_dbSet.AsQueryable(),
               (entity, property) => entity.Include(property))
          .Where(x => x.IsDelete == false)
          .ToListAsync();
          
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string includedProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
			foreach (var includeProperty in includedProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}
			return await query.ToListAsync();
        }

		public async Task<TEntity?> GetAsync(object id)
		{
			return await _dbSet.FindAsync(id);
		}

		public Task<TEntity?> GetByIdAsync(Guid id)
        {
            return this.GetByIdAsync(id, Array.Empty<Expression<Func<TEntity, object>>>());
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
             .Aggregate(_dbSet.AsQueryable(),
                 (entity, property) => entity.Include(property))
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id.Equals(id) && (x.IsDelete == null || x.IsDelete == false));
        }

        public void Update(TEntity entity)
        {
            entity.ModificationDate = _timeService.GetCurrentTime();
            entity.ModificationBy = _claimService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ModificationDate = _timeService.GetCurrentTime();
                entity.ModificationBy = _claimService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }
    }
}
