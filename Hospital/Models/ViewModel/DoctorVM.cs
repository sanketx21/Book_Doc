using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Models.ViewModel
{
    public class DoctorVM
    {
        public Doctor Doctor { get; set; }

        public IEnumerable<SelectListItem> Departmentslist { get; set; }

    }
}
