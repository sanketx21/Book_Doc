using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Hospitals
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [DisplayName("Hospital Name")]
        public string? Name { get; set; }
        [Required]

        [DisplayName("Description")]
        public string? Description { get; set; }
        [Required]

        [DisplayName("Address")]
        public string? Address { get; set; }
        [Required]

        public string? ImageUrl { get; set; }

        //public int DoctorId { get; set; }
        //[ForeignKey("DoctorId")]
        //public Doctor Doctor { get; set; }

    }
}
