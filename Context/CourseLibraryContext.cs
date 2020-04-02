using System;
using Microsoft.EntityFrameworkCore;
using Simple.Api.Entities;

namespace Simple.Api.Context
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext( DbContextOptions<CourseLibraryContext> options) : base(options)
        {
        }

        protected CourseLibraryContext()
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(

                new Author()
                {
                  AuthorId=1,
                  FirstName="Javier",
                  LastName="Mayorga",
                  DateOfBirth=new DateTime(1994,06,07),
                  MaintCategory="Science Fiction"

                }
            );

        }
    }
}