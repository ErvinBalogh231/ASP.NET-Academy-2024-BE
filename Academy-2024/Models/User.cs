using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Role {  get; set; }

        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public ICollection<Course> Courses { get; set; } = [];
    }
}
