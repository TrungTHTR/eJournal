using Application.InterfaceRepository;
using AutoMapper;
using BusinessObject;

namespace Infrastructure.Mappers
{
	public class AuthorConverter : ITypeConverter<string, Author>
	{
		private readonly IAuthorRepository repository;

		public AuthorConverter(IAuthorRepository repository)
		{
			this.repository = repository;
		}

		public Author Convert(string source, Author destination, ResolutionContext context)
		{
			var author = repository.GetAuthor(Guid.Parse(source));
			if (author == null)
			{
				throw new Exception("Author doesn't exist");
			}
			return author;
		}
	}
}
