using Application;
using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using BusinessObject;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using AutoMapper;
using Application.Service;
using Microsoft.AspNetCore.OData.Routing.Attributes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ODataController
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Article> articles = await _articleService.GetAllArticle();
            if (articles == null)
            {
                return BadRequest();
            }
            return Ok(articles);
        }

        // GET api/<ArticleController>/search/5
        [HttpGet("search")]
        public async Task<IActionResult> SearchArticle(string value)
        {
            List<Article> articles = await _articleService.SearchArticle(value);
            if (articles != null)
            {
                return Ok(articles);
            }
            return NotFound();
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var article = await _articleService.GetArticles(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Article article)
        {
            var _article = await _articleService.GetArticles(article.Id);
            if (_article != null)
            {
                return BadRequest("Article has exist");
            }
            await _articleService.CreateArticle(article);
            return NoContent();
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Article article)
        {
            var _article = await _articleService.GetArticles(id);
            if (_article != null)
            {
                if (_article.Status.Equals("Draff") || _article.Status.Equals("Revise"))
                {
                    await _articleService.UpdateArticle(article);
                    return Ok(article);
                }
                else
                {
                    return BadRequest("Article can't do it right now!! ");
                }
            }
            return BadRequest("Article not exist");
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            int i = await _articleService.DeleteArticle(id);
            if (i > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }

        //NgoThiKhanhLy
        [HttpGet("unauthorized-user")]
        [EnableQuery]
        [ODataRouteComponent]
        [AllowAnonymous]
        public async Task<IQueryable<ArticleResponse>> GetArticles()
        {
            var articles = await _articleService.GetAll(ArticleStatus.Publish);
            return articles.AsQueryable();
        }
        //NgoThiKhanhLy
        [HttpPost("{id}/article-file")]
        [Authorize]
        public async Task<ActionResult<string>> AddArticleFile(IFormFile file, [FromRoute(Name = "id")] Guid id)
        {
            var url = await _articleService.AddArticleFile(file, id);
            return Ok(url);
        }


    }//end class
}//end namespace
