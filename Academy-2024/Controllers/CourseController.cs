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
        private CourseRepository _courseRepository;

        public CourseController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseRepository.GetById(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course toCreate)
        {
            _courseRepository.Create(toCreate);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course updateTo)
        {
            var course = _courseRepository.Update(id, updateTo);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}
