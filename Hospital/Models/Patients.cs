using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public string? Problem { get; set; }

        public int? Age { get; set; }

        public string? BloodGroup { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public string? Record { get; set; }
    }
}
