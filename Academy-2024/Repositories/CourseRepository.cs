using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _content;

        public CourseRepository(ApplicationDbContext content) { _content = content; }

        public Task<List<Course>> GetAllAsync() => _content.Courses.ToListAsync();

        // public List<Course> GetAuthors() => _content.Courses.Select(author => author.Author).ToList();

        public Task<Course?> GetByIdAsync(int id) => _content.Courses.FirstOrDefaultAsync(course => course.Id == id);

        public async Task CreateAsync(Course courseToAdd)
        {
            await _content.Courses.AddAsync(courseToAdd);
            await _content.SaveChangesAsync();
        }

        public async Task<Course?> UpdateAsync(int id, Course modifieTo)
        {
            var course = await _content.Courses.FirstOrDefaultAsync(course => course.Id == id);
            if (course != null)
            {
                course.CourseName = modifieTo.CourseName;
                course.CourseDescription = modifieTo.CourseDescription;
                course.Url = modifieTo.Url;

                await _content.SaveChangesAsync();

                return course;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _content.Courses.FirstOrDefaultAsync(course => course.Id == id);
            if (course != null)
            {
                _content.Courses.Remove(course);
                await _content.SaveChangesAsync();

                return true;
            }

            return false;
        }

    }
}
