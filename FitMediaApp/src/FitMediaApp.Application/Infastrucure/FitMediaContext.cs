﻿using Bogus;
using FitMediaApp.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Infastrucure
{
    public class FitMediaContext : DbContext
    {

        public FitMediaContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Follower> Followers => Set<Follower>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();

        //OnModelCreate
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follower>().HasOne(f => f.Sender).WithMany(u => u.FollowerSender).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Follower>().HasOne(f => f.Recipient).WithMany(u => u.FollowerRecipient).OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<User>().HasMany(e => e.Likes).WithMany(u => u.Likes);

            // Generic config for all entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // ON DELETE RESTRICT instead of ON DELETE CASCADE
                foreach (var key in entityType.GetForeignKeys())
                    key.DeleteBehavior = DeleteBehavior.Restrict;

                foreach (var prop in entityType.GetDeclaredProperties())
                {
                    // Define Guid as alternate key. The database can create a guid fou you.
                    if (prop.Name == "Guid")
                    {
                        modelBuilder.Entity(entityType.ClrType).HasAlternateKey("Guid");
                        prop.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    }
                    // Default MaxLength of string Properties is 255.
                    if (prop.ClrType == typeof(string) && prop.GetMaxLength() is null) prop.SetMaxLength(255);
                    // Seconds with 3 fractional digits.
                    if (prop.ClrType == typeof(DateTime)) prop.SetPrecision(3);
                    if (prop.ClrType == typeof(DateTime?)) prop.SetPrecision(3);
                }
            }
        }

        //Seed 
        public void Seed()
        {
            Randomizer.Seed = new Random(1039);
            var faker = new Faker("de");

            var users = new Faker<User>("de").CustomInstantiator(f =>
            {
                return new User(
                    mail: f.Name.FirstName() + "@gmail.com",
                    username: f.Name.FirstName(),
                    initialPassword: "1111",
                    profilePicPath: "uploads/090d347a36664385835d379c8d367e00.png",
                    bio: "This is a Bio")
                { Guid = f.Random.Guid() };
            })
            .Generate(10)
            .ToList();
            Users.AddRange(users);
            SaveChanges();

            var posts = new Faker<Post>("de").CustomInstantiator(f =>
            {
            return new Post(
                user: f.PickRandom(users),
                date: f.Date.Past(),
                filePathPic: "uploads/chirs.png",
                description: f.Lorem.Sentence())
                    { Guid = f.Random.Guid() };
            })
            .Generate(10)
            .ToList();
            Posts.AddRange(posts);
            SaveChanges();

            foreach (var post in posts)
            {
                var comments = new Faker<Comment>("de").CustomInstantiator(f =>
                {
                    return new Comment(
                        user: faker.PickRandom(users),
                        text: f.Lorem.Sentence(),
                        date: f.Date.Past())
                    { Guid = f.Random.Guid() };
                })
                .Generate(5) 
                .ToList();

                post.Comments.AddRange(comments);
            }

            SaveChanges();
        }




        //Ini
        private void Initialize()
        {
           
        }


        public void CreateDatabase(bool isDevelopment)
        {
            if (isDevelopment) { Database.EnsureDeleted(); }
            // EnsureCreated only creates the model if the database does not exist or it has no
            // tables. Returns true if the schema was created.  Returns false if there are
            // existing tables in the database. This avoids initializing multiple times.
            if (Database.EnsureCreated()) { Initialize(); }
            if (isDevelopment) Seed();
        }


    }
}

