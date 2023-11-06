using Application.ViewModels.UserViewModels;
using BusinessObject;

namespace Application.InterfaceRepository
{
	public interface IAuthorRepository
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author?> GetAuthorAsync(Guid id);
		Author? GetAuthor(Guid id);
		Task<Author?> GetAuthor(string identityCardNumber);
		Task<Author?> GetAuthorByAccountId(Guid id);
		Task CreateAuthor(Author request);
		void UpdateAuthor(Author request);
	}
}
