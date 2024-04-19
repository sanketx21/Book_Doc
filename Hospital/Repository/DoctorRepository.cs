using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private ApplicationDbContext _db;
        public DoctorRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        public void Update(Doctor obj)
        {
            _db.Docinfo.Update(obj);
        }

      
    }
}
