using Hospital.Models;

namespace Hospital.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Departments>
    {
        void Update(Departments obj);
    }
}
