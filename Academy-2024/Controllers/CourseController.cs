using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.GetAllAsync();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Course toCreate)
        {
            await _courseRepository.CreateAsync(toCreate);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Course updateTo)
        {
            var course = await _courseRepository.UpdateAsync(id, updateTo);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _courseRepository.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
