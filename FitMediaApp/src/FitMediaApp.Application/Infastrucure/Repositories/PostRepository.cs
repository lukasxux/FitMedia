using FitMediaApp.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var entity = await _db.Posts.Include(h => h.Comments).FirstOrDefaultAsync(h => h.Guid == guid);
            if (entity is null) { return (false, "Post not found"); }
            return await base.Delete(guid);
        }
        public override async Task<(bool success, string message)> Delete(int id)
        {
            var entity = _db.Posts.Include(h => h.Comments).FirstOrDefault(h => h.Id == id);
            if (entity is null) { return (false, "Post not found"); }
            return await base.Delete(id);
        }





    }
}

