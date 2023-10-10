using FitMediaApp.Application.Infastrucure;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using FitMediaApp.Application.Dto;
using FitMediaApp.Application.Model;
using System.Threading;

namespace FitMediaApp.Webapi.Controllers
{

    public class UserController : EntityReadController<User>
    {
        public UserController(FitMediaContext db, IMapper mapper) : base(db, mapper)
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() => await GetAll(u =>
        new
        {
            u.Guid,
            u.Mail,
            u.Username,
            u.Bio,
            FollowerCount = u.Followers.ToArray().Length,
            FollowingCount = u.Following.ToArray().Length,
            PostCount = u.Posts.ToArray().Length,
        });

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetUser(Guid guid) => await GetByGuid(guid ,u =>
        new
        {
            u.Guid,
            u.Mail,
            u.Username,
            u.Bio,
            FollowerCount = u.Followers.ToArray().Length,
            FollowingCount = u.Following.ToArray().Length,
            PostCount = u.Posts.ToArray().Length,
        });
    }
}
