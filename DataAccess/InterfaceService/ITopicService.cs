using Application.ViewModels.ArticleViewModels;

namespace Application.InterfaceService
{
	public interface ITopicService
	{
		Task<IEnumerable<TopicResponse>> GetTopics();
	}
}
