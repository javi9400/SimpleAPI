using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Simple.Api.Entities;
using Simple.Api.Services;

namespace Simple.Api.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository repo)
        {
            _courseLibraryRepository = repo?? throw new ArgumentNullException(nameof(repo));
        }


        [HttpGet("api/authors")]
        public ICollection<Author> GetAuthors()
        {
            var authorsFromRepo=_courseLibraryRepository.GetAuthors();
            return  authorsFromRepo;

        }

    }
}