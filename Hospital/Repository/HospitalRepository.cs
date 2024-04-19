using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.Repository
{
    public class HospitalRepository : Repository<Hospitals>, IHospitalRepository
    {
        private ApplicationDbContext _db;
        public HospitalRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Hospitals obj)
        {
            _db.Hospitalinfo.Update(obj);
        }
    }
}
