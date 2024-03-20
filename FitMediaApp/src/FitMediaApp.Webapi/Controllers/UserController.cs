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
using FitMediaApp.Application.Infastrucure.Repositories;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Docker.DotNet;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace FitMediaApp.Webapi.Controllers
{

    public class UserController : EntityReadController<User>
    {
        private readonly UserRepository _repo;
        private readonly PostRepository _postRepository;
        private readonly FitMediaContext _db;
        private readonly IConfiguration _config;

        public UserController(IMapper mapper, UserRepository repo, FitMediaContext db, IConfiguration config, PostRepository postRepository) : base(repo.Set, repo.Model, mapper)
        {
            _repo = repo;
            _db = db;
            _config = config;
            _postRepository = postRepository;

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() => await GetAll<UserDto>();

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetUser(Guid guid) => await GetByGuid(guid, u =>
        new
        {
            u.Guid,
            u.Mail,
            u.Username,
            u.Bio,
            u.ProfilePicPath,
            FollowerSender = u.FollowerSender.Select(a => new {
                Recipient = new
                {
                    a.Recipient.Guid
                }
            }),
            FollowerRecipient = u.FollowerRecipient.Select(a => new {
                Sender = new {
                a.Sender.Guid
                }
            }),
            u.Posts,
        });

        [Authorize]
        [HttpDelete()]
        public async Task<IActionResult> DeleteUser()
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) { return Unauthorized(); }
            var mail = HttpContext.User.Identity?.Name;
            if (mail is null) { return Unauthorized(); }
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Mail == mail);
            if (user is null) { return Unauthorized(); }
            var deleteUserResult = await _repo.Delete(user.Guid);
            if (!deleteUserResult.success)
            {
                return BadRequest(deleteUserResult.message);
            }

            var deletePostsResult = await _postRepository.DeletePostsForUser(user.Guid);
            if (!deletePostsResult.success)
            {
                return BadRequest(deletePostsResult.message);
            }

            return Ok("User and associated posts deleted successfully");

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.Guid = Guid.NewGuid();
            try
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("User added successfully. Guid: " + user.Guid);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto credentials)
        {
            var user = await _db.Users.FirstOrDefaultAsync(a => a.Mail == credentials.Email);
            if (user is null || !user.CheckPassword(credentials.Password)) return BadRequest("Password falsch oder User gibt es nicht");
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, credentials.Email),
            //new Claim(ClaimTypes.Role, "admin")
            };
            var claimsIdentity = new ClaimsIdentity(
                claims,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3),
            };

            await HttpContext.SignInAsync(
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return Ok("Sucess!!!");
        }

        [Authorize]
        [HttpPost("follow/{username}")]
        public async Task<IActionResult> Follow(string username)
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) { return Unauthorized(); }
            var mail = HttpContext.User.Identity?.Name;
            var userSender = await _db.Users.FirstOrDefaultAsync(u => u.Mail == mail);
            if (userSender is null) { return Unauthorized(); }
            var userRecipient = await _db.Users.FirstOrDefaultAsync(a => a.Username == username);
            if (userRecipient is null) { return BadRequest(); }
            var follow = await _db.Followers.FirstOrDefaultAsync(a => a.Sender == userSender && a.Recipient == userRecipient);
            if (follow is not null)
            {
                _db.Followers.Remove(follow);
                try { await _db.SaveChangesAsync(); }
                catch (DbUpdateException e) { return BadRequest(e.Message); }
                return Ok(_db.Followers.Where(a => a.Recipient.Guid == userRecipient.Guid).Count());
            }
            var follower = new Follower(userSender, userRecipient, DateTime.UtcNow.Date);
            _db.Followers.Add(follower);
            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateException e) { return BadRequest(e.Message); }
            return Ok(userSender.Username);
        }
    }
}

