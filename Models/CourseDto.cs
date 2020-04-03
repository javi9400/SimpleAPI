namespace Simple.Api.Models
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}