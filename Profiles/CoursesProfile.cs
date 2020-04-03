using AutoMapper;

namespace Simple.Api.Profiles
{
    public class CoursesProfile:Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course,Models.CourseDto>();
        }
    }
}