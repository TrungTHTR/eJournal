using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
	public interface ITopicRepository
	{
		public Task<IEnumerable<Topic>> GetTopics();
	}
}
