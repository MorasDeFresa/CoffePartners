using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class ModelPostsPost()
    {
        public required string TitlePost { get; set; }
        public required string DescriptionPost { get; set; }
        public required string ImgUrl { get; set; }
        public required int IdAdmin { get; set; }

    }

    public class ModelPostsPut()
    {
        public string? TitlePost { get; set; }
        public string? ImgUrl { get; set; }
        public string? DescriptionPost { get; set; }
        public int? IdAdmin { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _PostsRepository;

        public PostsController(IPostsRepository PostsRepository)
        {
            _PostsRepository = PostsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Posts>>> GetPostss()
        {
            try
            {
                return Ok(await _PostsRepository.GetPosts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdPosts}")]
        public async Task<ActionResult<Posts>> GetPosts(int IdPosts)
        {
            try
            {
                var Posts = await _PostsRepository.GetPosts(IdPosts);
                if (Posts == null)
                {
                    return NotFound("Posts not found");
                }
                return Ok(Posts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Posts>> CreatePosts(ModelPostsPost PostsPosts)
        {
            try
            {
                var Posts = new Posts
                {
                    TitlePost = PostsPosts.TitlePost,
                    ImgUrl = PostsPosts.ImgUrl,
                    DescriptionPost = PostsPosts.DescriptionPost,
                    IdAdmin = PostsPosts.IdAdmin,
                    DatePost = DateTime.Now
                };

                var createdPosts = await _PostsRepository.CreatePosts(Posts);
                if (createdPosts == null)
                {
                    return BadRequest("create Posts");
                }
                return CreatedAtAction(nameof(GetPostss), new { IdPosts = createdPosts.IdPost }, createdPosts);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdPosts}")]
        public async Task<ActionResult<Posts>> UpdatePosts(int IdPosts, ModelPostsPut PostsPut)
        {
            try
            {
                var Posts = await _PostsRepository.GetPosts(IdPosts);
                if (Posts == null) return BadRequest("update Posts");
                if (PostsPut.TitlePost != null) Posts.TitlePost = PostsPut.TitlePost;
                if (PostsPut.ImgUrl != null) Posts.ImgUrl = PostsPut.ImgUrl;
                if (PostsPut.DescriptionPost != null) Posts.DescriptionPost = PostsPut.DescriptionPost;
                if (PostsPut.IdAdmin != null) Posts.IdAdmin = (int)PostsPut.IdAdmin;
                Posts.DatePost = DateTime.Now;
                var updatedPosts = await _PostsRepository.UpdatePosts(Posts);
                if (updatedPosts == null)
                {
                    return NotFound();
                }
                return Ok(updatedPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdPosts}")]
        public async Task<ActionResult<Posts>> DeletePosts(int IdPosts)
        {
            try
            {
                var deletedPosts = await _PostsRepository.DeletePosts(IdPosts);
                if (deletedPosts == false)
                {
                    return NotFound();
                }
                return Ok(deletedPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}