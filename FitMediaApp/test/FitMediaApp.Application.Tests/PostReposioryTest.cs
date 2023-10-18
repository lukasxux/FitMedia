using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using FitMediaApp.Application.Infastrucure;
using FitMediaApp.Application.Infastrucure.Repositories;
using FitMediaApp.Application.Model;
using System.Collections.Generic;
using System.Linq;

namespace FitMediaApp.Application.Tests
{

    [Collection("Sequential")]  // Keine Parallelausführung
    public class HandinRepositoryTests
    {
        public FitMediaContext GetDatabase()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite("DataSource=test.db")
                .Options;
            var db = new FitMediaContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }
        [Fact]
        public async void DeleteSuccessTest()
        {
            // ARRANGE
            var db = GetDatabase();
            var repo = new PostRepository(db);

            var post = new Post(
                date: new DateTime(2020, 1, 1),
                filePathPic: "path",
                description: "something");
            db.Posts.Add(post);
            db.SaveChanges();
            db.ChangeTracker.Clear();

            // ACT
            await repo.Delete(post.Guid);

            // ASSERT
            Assert.True(db.Posts.Count() == 0);
        }

       
    }
}





