using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class TopicService : ITopicService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TopicResponse>> GetTopics()
		{
			var topics = await _unitOfWork.TopicRepository.GetTopics();
			return _mapper.Map<IEnumerable<TopicResponse>>(topics);
		}
	}
}
 