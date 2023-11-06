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
	public class TopicRepository : ITopicRepository
	{
		private AppDbContext _dbContext;

		public TopicRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Topic>> GetTopics()
		{
			return await _dbContext.Topic.ToListAsync();
		}
	}
}
