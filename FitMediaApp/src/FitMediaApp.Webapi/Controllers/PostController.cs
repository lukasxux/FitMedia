using AutoMapper;
using FitMediaApp.Application.Infastrucure;
using FitMediaApp.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using FitMediaApp.Application.Dto;
using FitMediaApp.Application.Infastrucure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FitMediaApp.Webapi.Controllers
{
    public class PostController : EntityReadController<Post>
    {
        private readonly PostRepository _repo;
        private readonly FitMediaContext _db;
        private readonly IConfiguration _config;

        public PostController(IMapper mapper, PostRepository repo, FitMediaContext db, IConfiguration config) : base(repo.Set, repo.Model, mapper)
        {
            _repo = repo;
            _db = db;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost() => await GetAll<PostDto>();

        [HttpGet("{guid:Guid}")]
        public async Task<IActionResult> GetPost(Guid guid) => await GetByGuid<PostDto>(guid);

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeletePost(Guid guid)
        {
            var (success, message) = await _repo.Delete(guid);
            if (!success) return BadRequest(message);
            return NoContent();
        }

        [HttpPost("uploadPost")]
        public async Task<IActionResult> uploadPost([FromBody] PostUploadDto newPost)
        {
            var post = _mapper.Map<Post>(newPost);
            try
            {
                await _db.Posts.AddAsync(post);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("User added successfully. Guid: " + post.Guid);
        }


    }
}