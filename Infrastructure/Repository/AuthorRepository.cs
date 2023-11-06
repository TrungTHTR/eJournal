using Application.InterfaceRepository;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public class AuthorRepository : IAuthorRepository
	{
		private AppDbContext _dbContext;

		public AuthorRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAuthor(Author request)
		{
			await _dbContext.Author.AddAsync(request);
		}

		public async Task<IEnumerable<Author>> GetAll()
		{
			try
			{
				var authors = await _dbContext.Author.ToListAsync();
				return authors;
			} catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<Author?> GetAuthorAsync(Guid id)
		{
			return await _dbContext.Author.FindAsync(id);
		}

		public async Task<Author?> GetAuthor(string identityCardNumber)
		{
			var author = await _dbContext.Author.FirstOrDefaultAsync(x => x.IdentityCardNumber == identityCardNumber);
			return author;
		}

		public void UpdateAuthor(Author request)
		{
			_dbContext.Author.Update(request);
		}

		public Author? GetAuthor(Guid id)
		{
			return _dbContext.Author.Find(id);
		}

		public async Task<Author?> GetAuthorByAccountId(Guid id)
		{
			return await _dbContext.Author.FirstOrDefaultAsync(x => x.AccountId == id);
		}
	}
}
