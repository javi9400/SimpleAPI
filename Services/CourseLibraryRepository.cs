using System;
using System.Collections.Generic;
using System.Linq;
using Simple.Api.Context;
using Simple.Api.Entities;

namespace Simple.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private CourseLibraryContext _context;
        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _context=context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddCourse(int authorId, Course course)
        {
            var newCourse=course;
            newCourse.AuthorId=authorId;

             _context.Courses.Add(newCourse);
             _context.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            var course= _context.Courses.Where(x=> x.CourseId==courseId).FirstOrDefault();

            _context.Remove(course);
            _context.SaveChanges();
        }

        public ICollection<Author> GetAuthors()
        {
           var authors= _context.Authors.ToList();
           
           if(authors==null)
           {
               throw new ArgumentNullException();
           }
          
          return  authors;
        }

        public ICollection<Course> GetAllCourse()
        {
          var courses= _context.Courses.ToList();
           if(courses==null)
           {
               throw new ArgumentNullException();
           }
          
          return  courses;
        }

        public Author GetAuthor(int authorId)
        {
            var author= _context.Authors.Where(x=> x.AuthorId==authorId).FirstOrDefault();
            return  author;
        }

        public Course GetCourse(int courseId)
        {
            var course= _context.Courses.Where(x=> x.CourseId==courseId).FirstOrDefault();
            return course;
        }

        public void UpdateCourse(Course course)
        {
           var actualCourse= _context.Courses.Where(x=> x.CourseId==course.CourseId).FirstOrDefault();

           actualCourse.Description=course.Description;
           actualCourse.Title=course.Title;
           actualCourse.AuthorId=course.AuthorId;

           _context.Add(actualCourse);

           _context.SaveChanges();
        }
    }
}