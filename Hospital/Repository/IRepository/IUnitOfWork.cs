namespace Hospital.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IHospitalRepository Hospital { get; } 
        
        IPatientRepository patient { get; }
        
        IDepartmentRepository Department{ get; }

        void Save();
    }
}
