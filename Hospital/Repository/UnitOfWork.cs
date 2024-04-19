using Hospital.HospitalData.Data;
using Hospital.Repository.IRepository;
using Hospital.Models;

namespace Hospital.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IDoctorRepository Doctor {  get; private set; }

        public IHospitalRepository Hospital {  get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public IPatientRepository patient { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Doctor = new DoctorRepository(_db);
            Hospital = new HospitalRepository(_db);
            patient = new PatientRepository(_db);
            Department= new DepartmentRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
