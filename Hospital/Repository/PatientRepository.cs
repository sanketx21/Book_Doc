using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public class PatientRepository : Repository<Patients>, IPatientRepository
    {
        private ApplicationDbContext _db;
        public PatientRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


       

        public void Update(Patients obj)
        {
            _db.PatientsList.Update(obj);
        }
    }
}
