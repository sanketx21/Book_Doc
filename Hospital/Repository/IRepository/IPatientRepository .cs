using Hospital.Models;

namespace Hospital.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patients>
    {
        void Update(Patients obj);
    }
}
