using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using AutoMapper;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Http;
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

        public async Task<string> AddArticleFile(IFormFile file)
        {
            var url = await _firebaseService.UploadFile(fileStream: file.OpenReadStream(), fileName: file.FileName, folder: nameof(FirebaseFolderName.articles));
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
    }
}
