using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                        CourseId=1,
                        Title="The return of the jedi",
                        Description="Star wars books",
                        AuthorId=1
                }
            );

            modelBuilder.Entity<Author>().HasData(

                new Author()
                {
                  AuthorId=1,
                  FirstName="Javier",
                  LastName="Mayorga",
                  DateOfBirth=new DateTime(1994,06,07),
                  MainCategory="Science Fiction"
                  
                }
            );

        }
    }
}