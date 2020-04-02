namespace Simple.Api.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}