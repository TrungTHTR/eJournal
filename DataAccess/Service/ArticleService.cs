
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

namespace Application.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFirebaseService _firebaseService;
        public ArticleService(IMapper mapper, IUnitOfWork unitOfWork, IFirebaseService firebaseService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _firebaseService = firebaseService;
        }

        public async Task<string> AddArticleFile(IFormFile file, Guid id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticles(id);
            if(article == null || (article.IsDelete != null && article.IsDelete.Value) || (!article.Status.Equals(nameof(ArticleStatus.Draft)) && !article.Status.Equals(nameof(ArticleStatus.Revise)))){
                throw new Exception("Article is not existed or not available for edit");
            }
            var url = await _firebaseService.UploadFile(fileStream: file.OpenReadStream(), fileName: file.FileName, folder: nameof(FirebaseFolderName.articles));
            article.ArticleFileUrl = url;
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
            return url;
        }

        public async Task DownloadArticleFile(Guid id)
        {
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if(article == null || article.ArticleFileUrl == null)
            {
                throw new Exception("Article is not available for downloading");
            }
            await _firebaseService.DownloadFile(article.ArticleFileUrl);
        }


        public async Task<IEnumerable<ArticleResponse>> GetAll(ArticleStatus? status)
        {
            var articles = await _unitOfWork.ArticleRepository.GetAllAsync(x => x.Status == nameof(status));
            return _mapper.Map<IEnumerable<ArticleResponse>>(articles);
        }

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> CreateArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.CreateArticle(article);
        }
        public async Task<int> DeleteArticle(Guid id)
        {
            return await _unitOfWork.ArticleRepository.DeleteArticle(id);
        }

        public async Task<List<Article>> GetAllArticle()
        {
            return await _unitOfWork.ArticleRepository.GetAllArticle();
        }

        public async Task<Article> GetArticles(Guid id)
        {
            return await _unitOfWork.ArticleRepository.GetArticles(id);
        }
        
        public async Task<int> UpdateArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.UpdateArticle(article);
        }
        //search Article By Title Or AuthorName
        public async Task<List<Article>> SearchArticle(string value)
        {
            return await _unitOfWork.ArticleRepository.SearchArticle(value);
        }
    }
}
