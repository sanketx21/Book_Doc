using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hospital.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Doctor Name")]
        [MaxLength(30)]
        public string? Name { get; set; }

        [DisplayName("Specialisation")]
        [MaxLength(50)]

        public string? Specialisation { get; set; }

        [DisplayName("Hospital Name")]
        [MaxLength(50)]
        public string? Hospital { get; set; }

        [DisplayName("Fees")]
        public double? Fees { get; set; }


        //public int DepartmentId { get; set; }
        //[ValidateNever]
        //[ForeignKey("DepartmentId")]
        //public Departments Department { get; set; }



    }
}
