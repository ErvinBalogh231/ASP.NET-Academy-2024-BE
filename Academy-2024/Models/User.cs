using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public int? Age { get; set; }
    }
}
