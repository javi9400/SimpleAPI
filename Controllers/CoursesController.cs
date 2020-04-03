using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple.Api.Models;
using Simple.Api.Services;

namespace Simple.Api.Controllers
{
    [ApiController]
    [Route("api/authors/{authorid}/courses")]
    public class CoursesController:ControllerBase
    {
         private readonly ICourseLibraryRepository _courseLibraryRepository;
         private readonly IMapper _mapper;
        public CoursesController(ICourseLibraryRepository repo, IMapper mapper)
        {
             _courseLibraryRepository = repo?? throw new ArgumentNullException(nameof(repo));
            _mapper=mapper??throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourses(int authorId)
        {   
            var author=_courseLibraryRepository.GetAuthor(authorId);

            if(author==null)
            {
                return NotFound();
            }

            var coursesFromRepo=_courseLibraryRepository.GetAllCourse(authorId);

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesFromRepo));


        }

         [HttpGet("{courseId}")]
         public ActionResult<CourseDto> GetCourse(int authorId,int courseId)
         {
            
            throw new Exception();

           var author=_courseLibraryRepository.GetAuthor(authorId);

            if(author==null)
            {
                return NotFound();
            }

            var courseFromRepo=_courseLibraryRepository.GetCourse(authorId,courseId);

            if(courseFromRepo==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CourseDto>(courseFromRepo));

         }

    }
}