using FitMediaApp.Application.Infastrucure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitMediaApp.Webapi.Controllers
{
    public record UploadFileCmd(Guid UserGuid, IFormFile? File);
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly FitMediaContext _db; 
        private static string[] _allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

        public FileController(IConfiguration config, FitMediaContext db)
        {
            _config = config;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileCmd cmd)
        {
            if (cmd.File is null) return BadRequest("Missing file.");
            if (cmd.File.Length > 1024 * 1024) return BadRequest("Invalid filesize.");
            var extension = new FileInfo(cmd.File.FileName).Extension;
            if (!_allowedExtensions.Contains(extension)) return BadRequest("Invalid extension.");

            var user = _db.Users.FirstOrDefault(u => u.Guid == cmd.UserGuid);
            if (user is null) return BadRequest("Invalid user.");
            var filename = Guid.NewGuid().ToString("n") + extension;
            using (var destStream = new FileStream(Path.Combine(_config["UploadDirectory"], filename), FileMode.Create, FileAccess.Write))
            {
                await cmd.File.CopyToAsync(destStream);
            }

            user.ProfilePicPath = $"{_config["UploadDirectory"]}/{filename}";
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
