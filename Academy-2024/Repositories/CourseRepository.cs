using Academy_2024.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class CourseRepository
    {
        private static List<Course> Courses = new List<Course>
        { 
            new Course { Id = 1, CourseName = "ASP.NET", CourseDescription = "Megismered a ASP.NET alapjait" }
        };

        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course? GetById(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id) return course;
            }
            return null;
        }

        public void Create(Course courseToAdd)
        {
            Courses.Add(courseToAdd);
        }

        public Course? Update(int id, Course modifieTo)
        {
            foreach (var course in Courses)
            {
                if  (course.Id == id)
                {
                    course.CourseName = modifieTo.CourseName;
                    course.CourseDescription = modifieTo.CourseDescription;

                    return course;
                }
            }
            return null;
        }

        public bool Delete(int id)
        {
            foreach(var course in Courses)
            {
                if (course.Id == id)
                {
                    Courses.Remove(course);

                    return true;
                }
            }

            return false;
        }

    }
}
