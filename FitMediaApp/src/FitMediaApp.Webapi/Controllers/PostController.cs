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
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;

namespace FitMediaApp.Webapi.Controllers
{
    public class PostController : EntityReadController<Post>
    {
        private readonly PostRepository _repo;
        private readonly FitMediaContext _db;
        private readonly IConfiguration _config;
        private static string[] _allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        public record UploadPostCmd(string Description, IFormFile? File);

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

        [HttpPost("like/{guid}")]
        public async Task<IActionResult> LikePost(Guid guid)
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) { return Unauthorized(); }
            var mail = HttpContext.User.Identity?.Name;
            if (mail is null) { return Unauthorized(); }
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Mail == mail);
            if (user is null) { return Unauthorized(); }
            var post = await _db.Posts.Include(a => a.Likes).FirstOrDefaultAsync(u => u.Guid == guid);
            if (post is null) { return BadRequest("Post gibt es nícht"); }
            if (post.Likes.Contains(user))
            {
                post.Likes.Remove(user);
                try { await _db.SaveChangesAsync(); } catch (DbUpdateException e) { return BadRequest(e.Message); }
                return Ok(post.Likes.Count);
            }
            else {
                post.Likes.Add(user);
                await _db.SaveChangesAsync();
                return Ok(post.Likes.Count());
            }
            
        }

        [HttpPost("comment")]
        public async Task<IActionResult> CommentPost(commentDtoUpload comment)
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) { return Unauthorized(); }
            var mail = HttpContext.User.Identity?.Name;
            if (mail is null) { return Unauthorized(); }
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Mail == mail);
            if (user is null) { return Unauthorized(); }
            var post = await _db.Posts.Include(e => e.User).Include(a => a.Likes).FirstOrDefaultAsync(u => u.Guid == comment.guid);
            if (post is null) { return BadRequest("Post gibt es nícht"); }
            var com = new Comment(user, comment.Text, comment.Date);
            com.Guid = Guid.NewGuid();
            _db.Comments.Add(com);
            post.Comments.Add(com);
            await _db.SaveChangesAsync();
            return Ok(post.User.Username);
        }

        [HttpPost("uploadPost")]
        public async Task<IActionResult> UploadFileProfilePicture([FromForm] UploadPostCmd cmd)
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) { return Unauthorized(); }
            var mail = HttpContext.User.Identity?.Name;
            if (mail is null) { return Unauthorized(); }
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Mail == mail);
            if (user is null) { return Unauthorized(); }
            if (cmd.File is null) return BadRequest("Missing file.");
            if (cmd.File.Length > 1024 * 1024) return BadRequest("Invalid filesize.");
            var extension = new FileInfo(cmd.File.FileName).Extension;
            if (!_allowedExtensions.Contains(extension)) return BadRequest("Invalid extension.");
            if (user is null) return BadRequest("Invalid user.");
            var filename = Guid.NewGuid().ToString("n") + extension;
            using (var destStream = new FileStream(Path.Combine(_config["UploadDirectory"], filename), FileMode.Create, FileAccess.Write))
            {
                await cmd.File.CopyToAsync(destStream);
            }
            await _db.SaveChangesAsync();
            var post = new Post(
                user: user,
                date: DateTime.Now,
                filePathPic: $"{_config["UploadDirectory"]}/{filename}",
                description: cmd.Description
                ) {  Guid = Guid.NewGuid() };
            try {
                await _db.Posts.AddAsync(post);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Post added successfully. Guid: " + post.Guid);
        }
    }
}