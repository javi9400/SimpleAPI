using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Simple.Api.Entities;
using Simple.Api.Services;

namespace Simple.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository repo)
        {
            _courseLibraryRepository = repo?? throw new ArgumentNullException(nameof(repo));
        }


        [HttpGet]
        public ActionResult GetAuthors()
        {
            var authorsFromRepo=_courseLibraryRepository.GetAuthors();
            return Ok(authorsFromRepo);
        }

        [HttpGet("{authorId}")]
        public ActionResult GetAuthor(int authorId)
        {
                var author=_courseLibraryRepository.GetAuthor(authorId);
                
                if(author==null)
                {
                    return NotFound();
                }

                return Ok(author);
        }

    }
}