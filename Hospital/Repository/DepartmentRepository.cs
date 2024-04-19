using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public class DepartmentRepository : Repository<Departments>, IDepartmentRepository
    {
        private ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        public void Update(Departments obj)
        {
            _db.DepartmentList.Update(obj);
        }
    }
}
