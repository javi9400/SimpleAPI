using System;
using System.Collections.Generic;

namespace Simple.Api.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string MaintCategory { get; set; }

        public ICollection<Course> Courses{get;set;}= new List<Course>();

    }
}