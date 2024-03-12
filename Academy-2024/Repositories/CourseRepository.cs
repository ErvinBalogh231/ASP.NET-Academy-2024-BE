using Academy_2024.Data;
using Academy_2024.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class CourseRepository
    {
        private readonly Applicationdbcontent _content;

        public CourseRepository(Applicationdbcontent content) { _content = content; }

        public List<Course> GetAll() { return _content.Courses.ToList(); }

        public Course? GetById(int id) => _content.Courses.FirstOrDefault(course => course.Id == id);

        public void Create(Course courseToAdd)
        {
            _content.Courses.Add(courseToAdd);
            _content.SaveChanges();
        }

        public Course? Update(int id, Course modifieTo)
        {
            var course = _content.Courses.FirstOrDefault(course => course.Id == id);
                if  ( course != null )
                {
                    course.CourseName = modifieTo.CourseName;
                    course.CourseDescription = modifieTo.CourseDescription;
                    course.Url = modifieTo.Url;

                    _content.SaveChanges();

                    return course;
                }
            return null;
        }

        public bool Delete(int id)
        {
            var course = _content.Courses.FirstOrDefault(course => course.Id == id);
            if (course != null)
            {
                _content.Courses.Remove(course);
                _content.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
