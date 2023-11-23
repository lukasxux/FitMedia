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

namespace FitMediaApp.Webapi.Controllers
{

    public class UserController : EntityReadController<User>
    {
        private readonly UserRepository _repo;
        private readonly FitMediaContext _db;
        private readonly IConfiguration _config;

        public UserController(IMapper mapper, UserRepository repo, FitMediaContext db, IConfiguration config) : base(repo.Set, repo.Model, mapper)
        {
            _repo = repo;
            _db = db;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() => await GetAll<UserDto>();

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

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteUser(Guid guid)
        {
            var (success, message) = await _repo.Delete(guid);
            if (!success) return BadRequest(message);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto newUser)
        {
            var user = _mapper.Map<User>(newUser);
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
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {

            var secret = Convert.FromBase64String(_config["Secret"]);
            var lifetime = TimeSpan.FromHours(3);
            // Find the user in the database based on the provided email
            var user = _db.Users.FirstOrDefault(u => u.Mail == loginDto.Email);

            // If the user is not found or the password doesn't match, return an unauthorized response
            if (user == null || !user.CheckPassword(loginDto.Password))
            {
                return Unauthorized("Invalid email or password.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Payload for our JWT.
                Subject = new ClaimsIdentity(new Claim[]
                {
                // Write username to the claim (the "data zone" of the JWT).
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                    // Write the role to the claim (optional)
                }),
                Expires = DateTime.UtcNow + lifetime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Return the token so the client can save this to send a bearer token in the
            // subsequent requests.
            return Ok(new
            {
                user.Username,
                UserGuid = user.Guid,
                Token = tokenHandler.WriteToken(token)
            });
        }
    }
}
