using AutoMapper;
using FitMediaApp.Application.Infastrucure;
using FitMediaApp.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace FitMediaApp.Webapi.Controllers
{
    public class PostController : EntityReadController<Post>
    {
        public PostController(FitMediaContext db, IMapper mapper) : base(db, mapper)
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetPosts() => await GetAll(p =>
        new
        {
            p.Guid,
            p.Description,
            p.Comments.ToArray().Length
        });
        
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetUser(Guid guid) => await GetByGuid(guid, p =>
        new
        {
            p.Guid,
            p.Description,
            p.Comments.ToArray().Length
        });
    }
}
