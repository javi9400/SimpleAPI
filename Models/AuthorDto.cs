using System;

namespace Simple.Api.Models
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
    
        public string Name {get;set;}

        public int Age { get; set; }

        public string MainCategory { get; set; }

    }
}