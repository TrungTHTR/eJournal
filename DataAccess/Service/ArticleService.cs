
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using AutoMapper;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Http;
using Application.InterfaceService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.RequestReviewViewModel;

namespace Application.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFirebaseService _firebaseService;
        private readonly IUserService _userService;
        private readonly IRequestReviewService _requestReviewService;
        public ArticleService(IMapper mapper, IUnitOfWork unitOfWork, IFirebaseService firebaseService, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _firebaseService = firebaseService;
            _userService = userService;
        }

        public async Task<string> AddArticleFile(IFormFile file, Guid id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticles(id);
            var user = await _userService.GetCurrentLoginUser();
            if (!article.AuthorName.Equals(user.UserName))
            {
                throw new Exception("You don't have the right to modify this article");
            }
            if(article == null || (article.IsDelete != null && article.IsDelete.Value) || (!article.Status.Equals(nameof(ArticleStatus.Draft)) && !article.Status.Equals(nameof(ArticleStatus.Revise)))){
                throw new Exception("Article is not existed or not available for edit");
            }
            var url = await _firebaseService.UploadFile(fileStream: file.OpenReadStream(), fileName: file.FileName, folder: nameof(FirebaseFolderName.articles));
            article.ArticleFileUrl = url;
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
            return url;
        }

        public async Task<IEnumerable<ArticleResponse>> GetAll(ArticleStatus? status)
        {
            var articles = await _unitOfWork.ArticleRepository.GetAllAsync(filter: x => x.Status.Equals(status.ToString()), includedProperties: $"{nameof(Article.Topic)},{nameof(Article.Issue)}");
            return _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResponse>>(articles);
        }
        public async Task<int> CreateArticle(ArticleRequest request)
        {
            var article = _mapper.Map<Article>(request);
            article.Status = nameof(ArticleStatus.Draft);
            await _unitOfWork.ArticleRepository.AddAsync(article);
            return await _unitOfWork.SaveAsync();
        }
        public async Task<int> DeleteArticle(Guid id)
        {
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if (article == null)
            {
                throw new Exception("Article is not existed");
            }
            if(article.Status == nameof(ArticleStatus.Publish) || article.Status == nameof(ArticleStatus.Accept))
            {
                throw new Exception("Can't delete published or accepted article");
            }
            _unitOfWork.ArticleRepository.Delete(article);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<Article>> GetAllArticle()
        {
            return await _unitOfWork.ArticleRepository.GetAllArticle();
        }
        
        public async Task<Article> GetArticles(Guid id)
        {
            var article = _unitOfWork.ArticleRepository.GetAllAsync(filter: x => x.Id == id && x.Status == nameof(ArticleStatus.Publish), includedProperties: $"{nameof(Article.Issue)},{nameof(Article.Author)},{nameof(Article.Topic)}").Result.First();
			return article;
        }

		public async Task<Article> GetArticlesForAuthor(Guid id)
		{
			var article = await _unitOfWork.ArticleRepository.GetArticles(id);
			if (article == null)
			{
				throw new Exception("Article doesn't exist");
			}
			if (article.Status != nameof(ArticleStatus.Publish))
			{
				throw new Exception("You don't have the right to access this article");
			}
			return article;
		}

		public async Task<int> UpdateArticle(Guid id, ArticleRequest request)
        {
            var article = await _unitOfWork.ArticleRepository.GetAsync(id);
            if (article == null)
            {
                throw new Exception("Article doesn't exist");
            }
            if(article.Status != nameof(ArticleStatus.Draft) || article.Status != nameof(ArticleStatus.Revise))
            {
                throw new Exception("Article is not allowed to modify");
            }
            Account user = await _userService.GetCurrentLoginUser();
            if(!article.Author.Any(x => x.AccountId == user.Id))
            {
                throw new Exception("You are not allowed to modify this article");
            }
            article = _mapper.Map(request, article);
            _unitOfWork.ArticleRepository.Update(article);
            return await _unitOfWork.SaveAsync();
        }
        //search Article By Title Or AuthorName
        public async Task<List<Article>> SearchArticle(string value)
        {
            return await _unitOfWork.ArticleRepository.SearchArticle(value);
        }

		public async Task SubmitArticle(Guid id)
		{
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(id, x => x.Author);
            if (article == null)
            {
                throw new Exception("Article doesn't exist");
            }
            if(!article.Author.Any(x => x.AccountId == _userService.GetCurrentLoginUser().Result.Id))
            {
                throw new Exception("You don't have the right to modify this article");
            }
            if(article.Status != nameof(ArticleStatus.Draft) && article.Status != nameof(ArticleStatus.Revise))
            {
                throw new Exception("Only draft or revised article can be submitted");
            }
            article.Status = nameof(ArticleStatus.Review);
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
            await _requestReviewService.CreateRequestReview(new CreateRequestReview
            {
                RequestTitle = article.Title,
                RequestDate = DateTime.UtcNow,
                ArticleId = article.Id
            });
        }

		public async Task<IEnumerable<ArticleResponse>> GetArticlesByCurrentLoginUser()
		{
            Account user = await _userService.GetCurrentLoginUser();
            var author = await _unitOfWork.AuthorRepository.GetAuthorByAccountId(user.Id);
            if(author == null)
            {
                throw new Exception("User hasn't registered as an author");
            }
			var articles = await _unitOfWork.ArticleRepository.GetAllAsync(
                filter: x => x.Author.FirstOrDefault(y => y.Id == author.Id) != null, includedProperties: $"{nameof(Article.Issue)},{nameof(Article.Author)},{nameof(Article.Topic)}");
			return _mapper.Map<IEnumerable<ArticleResponse>>(articles);
		}

		public async Task<ArticleResponse> GetArticleByCurrentLoginUser(string articleId)
		{
			Account user = await _userService.GetCurrentLoginUser();
			var author = await _unitOfWork.AuthorRepository.GetAuthorByAccountId(user.Id);
			if (author == null)
			{
				throw new Exception("User hasn't registered as an author");
			}
			var article = _unitOfWork.ArticleRepository.GetAllAsync(
				filter: x => x.Id == _mapper.Map<Guid>(articleId) && x.Author.FirstOrDefault(y => y.Id == author.Id) != null, includedProperties: $"{nameof(Article.Issue)},{nameof(Article.Author)},{nameof(Article.Topic)}").Result.First();
			return _mapper.Map<ArticleResponse>(article);
		}

		public async Task PublishArticle(Guid articleId, Guid issueId)
		{
            var article = await _unitOfWork.ArticleRepository.GetAsync(articleId);
            if(article == null || article.Status != nameof(ArticleStatus.Accept))
            {
                throw new Exception("Article is not available for publish");
            }
            article.Status = nameof(ArticleStatus.Publish);
            article.IssueId = issueId;
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
		}
	}
}
