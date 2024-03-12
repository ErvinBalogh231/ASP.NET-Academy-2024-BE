using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? CourseName { get; set; }

        [Required]
        public string? CourseDescription { get; set; }

        [Required]
        public string? Url { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}
