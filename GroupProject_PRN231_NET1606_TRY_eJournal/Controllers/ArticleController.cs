﻿using Application;
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
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupProject_PRN231_NET1606_TRY_eJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class ArticleController : ODataController
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("author")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> GetArticlesByCurrentLoginUser()
        {
            var articles = await _articleService.GetArticlesByCurrentLoginUser();
            return Ok(articles);
        }

		[HttpGet("{id}/author")]
		[Authorize(Roles = "Author")]
		public async Task<IActionResult> GetArticleByCurrentLoginUser([FromRoute] string id)
		{
			var article = await _articleService.GetArticleByCurrentLoginUser(id);
			return Ok(article);
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
        [HttpGet("draft")]
        public async Task<IActionResult> GetDraftArticles()
        {
            var articles = await _articleService.GetAll(ArticleStatus.Draft);
            List<ArticleResponse> articleResponses= (List<ArticleResponse>)articles;
            return Ok(articleResponses);
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
        [AllowAnonymous]
        public async Task<ActionResult<ArticleResponse>> Get(Guid id)
        {
            var article = await _articleService.GetArticles(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // POST api/<ArticleController>
        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleRequest article)
        {
            *//* var _article = await _articleService.GetArticles(article.Id);
             if (_article != null)
             {
                 return BadRequest("Article has exist");
             }*//*
        }*/
        [Authorize(Roles = "Author")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleRequest article)
        {
            await _articleService.CreateArticle(article);
            return Ok();
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ArticleRequest article)
        {
            await _articleService.UpdateArticle(id, article);
            return NoContent();
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

        [HttpPut("{id}/article-submission")]
        public async Task SubmitArticle([FromRoute] Guid id)
        {
            await _articleService.SubmitArticle(id);
        }

        [HttpPut("{articleId}/publish")]
        [Authorize(Roles = "Director")]
        public async Task PublishArticle([FromRoute] Guid articleId, [FromQuery] Guid issueId)
        {
            await _articleService.PublishArticle(articleId, issueId);
        }

        [HttpGet("unauthorized-user")]
        [EnableQuery]
        [AllowAnonymous]
        public async Task<IQueryable<ArticleResponse>> GetArticles()
        {
            var articles = await _articleService.GetAll(ArticleStatus.Publish);
            return articles.AsQueryable();
        }

        [HttpPost("{id}/article-file")]
        [Authorize(Roles = "Author")]
        public async Task<ActionResult<string>> AddArticleFile(IFormFile file, [FromRoute(Name = "id")] Guid id)
        {
            var url = await _articleService.AddArticleFile(file, id);
            return Ok(url);
        }


    }//end class
}//end namespace
