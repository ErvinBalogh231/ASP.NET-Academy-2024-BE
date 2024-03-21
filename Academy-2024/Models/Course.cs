using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy_2024.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? CourseName { get; set; }

        public string? CourseDescription { get; set; }

        [Required]
        public string? Url { get; set; }

        //n n relation
        public ICollection<User> Users { get; set; } = [];

        //foreign key for 1 n realtion
        public int? AuthorId { get; set; }
        public User? Author { get; set; } = null!;
    }
}
