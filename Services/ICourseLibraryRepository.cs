using System.Collections.Generic;
using Simple.Api.Entities;

namespace Simple.Api.Services
{
    public interface ICourseLibraryRepository
    {
        void AddCourse(int authorId,Course course);
        void UpdateCourse(Course course);

        void DeleteCourse(int courseId);

        void AddAuthor(Author author);

        Course GetCourse(int authorId,int courseId);
        ICollection<Course> GetAllCourse(int authorId);

        Author GetAuthor(int authorId);

        ICollection<Author> GetAuthors();

    }
}