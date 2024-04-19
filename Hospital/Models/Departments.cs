using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //public int DepartmentId { get; set; }

        [DisplayName("Department")]
        public string DepartmentName { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        //[ForeignKey("Doctor")]
        //public int DoctorId { get; set; }
        
        //public ICollection<Doctor> Doctors { get; set; }
    }
}
