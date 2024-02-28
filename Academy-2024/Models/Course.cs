using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class Course
    {
        [Required(ErrorMessage = "ID is required.")]
        public int? Id { get; set; }

        public string? CourseName { get; set; }

        [MinLength(10)]
        public string? CourseDescription { get; set; }
    }
}
