using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Application.ViewModels.ArticleViewModels;
using Application.InterfaceService;
using AutoMapper;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Authorization;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ODataController
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("unauthorized-user")]
        [EnableQuery]
        [AllowAnonymous]
        public async Task<IQueryable<ArticleResponse>> GetArticles()
        {
            var articles = await _articleService.GetAll(ArticleStatus.Publish);
            return articles.AsQueryable();
        }
    }
}
