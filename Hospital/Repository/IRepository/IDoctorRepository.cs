using Hospital.Models;

namespace Hospital.Repository.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor obj);

        
    }
}
