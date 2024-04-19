using Hospital.Models;

namespace Hospital.Repository.IRepository
{
    public interface IHospitalRepository : IRepository<Hospitals>
    {
        void Update(Hospitals obj);
    }
}
