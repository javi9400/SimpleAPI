using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple.Api.Entities;
using Simple.Api.Helpers;
using Simple.Api.Models;
using Simple.Api.Services;

namespace Simple.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository repo,IMapper mapper)
        {
            _courseLibraryRepository = repo?? throw new ArgumentNullException(nameof(repo));
            _mapper=mapper??throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepo=_courseLibraryRepository.GetAuthors();

            var mappedDto=_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

            return Ok(mappedDto);
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(int authorId)
        {
                var author=_courseLibraryRepository.GetAuthor(authorId);
                
                if(author==null)
                {
                    return NotFound();
                }
                var mappedDto=_mapper.Map<AuthorDto>(author);

                return Ok(mappedDto);
        }

    }
}