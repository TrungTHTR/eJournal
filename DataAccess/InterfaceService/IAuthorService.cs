using Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
	public interface IAuthorService
	{
		Task<IEnumerable<AuthorResponse>> GetAuthors();
		Task<AuthorResponse> GetAuthor(Guid id);
		Task<AuthorResponse> GetAuthor(string identityCardNumber);
		Task CreateAuthor(AuthorRequest request);
		Task RegisterAuthor(AuthorRequest request);
	}
}
