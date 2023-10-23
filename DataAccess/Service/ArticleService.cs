using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using AutoMapper;
using BusinessObject.Enums;
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

        public ArticleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ArticleResponse>> GetAll(ArticleStatus? status)
        {
            var articles = await _unitOfWork.ArticleRepository.GetAllAsync(x => x.Status == nameof(status));
            return _mapper.Map<IEnumerable<ArticleResponse>>(articles);
        }
    }
}
