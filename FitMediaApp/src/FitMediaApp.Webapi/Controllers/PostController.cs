using AutoMapper;
using FitMediaApp.Application.Infastrucure;
using FitMediaApp.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using FitMediaApp.Application.Dto;
using FitMediaApp.Application.Infastrucure.Repositories;

namespace FitMediaApp.Webapi.Controllers
{
    public class PostController : EntityReadController<Post>
    {
        private readonly PostRepository _repo;
        public PostController(IMapper mapper, PostRepository repo) : base(repo.Set, repo.Model, mapper)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost() => await GetAll<PostDto>();

        [HttpGet("{guid:Guid}")]
        public async Task<IActionResult> GetPost(Guid guid) => await GetByGuid<PostDto>(guid);

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteHandin(Guid guid)
        {
            var (success, message) = await _repo.Delete(guid);
            if (!success) return BadRequest(message);
            return NoContent();
        }
    }
}