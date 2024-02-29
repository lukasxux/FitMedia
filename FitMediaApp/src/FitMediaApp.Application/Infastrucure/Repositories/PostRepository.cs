using FitMediaApp.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Infastrucure.Repositories
{
    public class PostRepository : Repository<Post, int>
    {
        public PostRepository(FitMediaContext db) : base(db)
        {
        }

        public override async Task<(bool success, string message)> Delete(Guid guid)
        {
            var post = await _db.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Guid == guid);
            if (post == null)
            {
                return (false, "Post not found");
            }
            foreach (var comment in post.Comments)
            {
                _db.Comments.Remove(comment);
            }

            return await base.Delete(guid);
        }

        public override async Task<(bool success, string message)> Delete(int id)
        {
            var post = await _db.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
            {
                return (false, "Post not found");
            }

            foreach (var comment in post.Comments)
            {
                _db.Comments.Remove(comment);
            }

            return await base.Delete(id);
        }

        public async Task<(bool success, string message)> DeletePostsForUser(Guid userGuid)
        {
            var posts = await _db.Posts.Where(p => p.User.Guid == userGuid).ToListAsync();
            foreach (var post in posts)
            {
                foreach (var comment in post.Comments)
                {
                    _db.Comments.Remove(comment);
                }
            }

            _db.Posts.RemoveRange(posts);
            await _db.SaveChangesAsync();

            return (true, "Posts for user deleted successfully");
        }
    }
}
