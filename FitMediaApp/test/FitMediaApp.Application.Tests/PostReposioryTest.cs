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

        /*[Fact]
        public async void DeleteFailIfTaskIsExpiredTest()
        {
            // ARRANGE
            var db = GetDatabase();
            var repo = new HandinRepository(db);

            var handin = new Handin(
                student: new Student(studentNr: 1, firstname: "firstname", lastname: "lastname", email: "email"),
                task: new Task("subject", "title",
                    team: new Team("name", "schoolclass"),
                    teacher: new Teacher("firstname", "lastname", "email"),
                    expirationDate: new DateTime(2021, 1, 1),
                    maxPoints: null),
                created: new DateTime(2024, 1, 1),
                description: "description",
                documentUrl: "documentUrl");
            db.Handins.Add(handin);
            db.SaveChanges();
            db.ChangeTracker.Clear();

            // ACT
            var (success, message) = await repo.Delete(handin.Guid);

            // ASSERT
            Assert.False(success);
            Assert.True(db.Handins.Count() == 1);
        }*/
    }
}





