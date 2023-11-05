using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class AuthorService : IAuthorService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public AuthorService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_userService = userService;
		}

		public async Task CreateAuthor(AuthorRequest request)
		{
			if(_unitOfWork.AuthorRepository.GetAuthor(request.IdentityCardNumber).Result != null)
			{
				throw new Exception("Author has been registered before");
			}
			var author = _mapper.Map<Author>(request);
			await _unitOfWork.AuthorRepository.CreateAuthor(author);
			await _unitOfWork.SaveAsync();
		}

		public async Task<AuthorResponse> GetAuthor(Guid id)
		{
			var author = await _unitOfWork.AuthorRepository.GetAuthorAsync(id);
			return _mapper.Map<AuthorResponse>(author);
		}

		public async Task<AuthorResponse> GetAuthor(string identityCardNumber)
		{
			var author = await _unitOfWork.AuthorRepository.GetAuthor(identityCardNumber);
			return _mapper.Map<AuthorResponse>(author);
		}

		public async Task<IEnumerable<AuthorResponse>> GetAuthors()
		{
			var authors = await _unitOfWork.AuthorRepository.GetAll();
			return _mapper.Map<IEnumerable<AuthorResponse>>(authors);
		}

		public async Task RegisterAuthor(AuthorRequest request)
		{
			var user = await _userService.GetCurrentLoginUser();
			var author = await _unitOfWork.AuthorRepository.GetAuthor(request.IdentityCardNumber);
			if (author == null)
			{
				author = _mapper.Map<Author>(request);
			}
			author.AccountId = user.Id;
			_unitOfWork.AuthorRepository.UpdateAuthor(author);
			user.RoleId = 4;
			await _unitOfWork.SaveAsync();
		}
	}
}
