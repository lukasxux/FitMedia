using FitMediaApp.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Infastrucure.Repositories
{
    public  class UserRepository : Repository<User, int>
    {
        public UserRepository(FitMediaContext db) : base(db)
        {
        }
           public override async Task<(bool success, string message)> Delete(Guid guid)
        {
            var user = await _db.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Guid == guid);
            if (user == null)
            {
                return (false, "User not found");
            }

            foreach (var post in user.Posts)
            {
                _db.Comments.RemoveRange(post.Comments);
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return (true, "User and associated posts deleted successfully");
        }

    
    public override async Task<(bool success, string message)> Delete(int id)
        {
            var entity = _db.Users.Include(h => h.Posts).FirstOrDefault(h => h.Id == id);
            if (entity is null) { return (false, "User not found"); }
            return await base.Delete(id);
        }


        public override async Task<(bool success, string message)> Insert(User user)
        {
           return await base.Insert(user);
        }


    }
}
