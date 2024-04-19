using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.HospitalData.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Doctor> Docinfo { get; set; }
        public DbSet<Hospitals> Hospitalinfo { get; set; }

        public DbSet<Departments> DepartmentList{ get; set; }
        public DbSet<Patients> PatientsList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "test1", Specialisation = "neuro", Hospital = "Appolo", Fees = 500.00},
                new Doctor { Id = 2, Name = "test2", Specialisation = "ortho", Hospital = "United", Fees = 1000.00 },
                new Doctor { Id = 3, Name = "test3", Specialisation = "surgeon", Hospital = "Narayana", Fees = 700.00 });

            modelBuilder.Entity<Hospitals>().HasData(
                new Hospitals { Id = 1, Name = "test1", Description = "neuro", Address = "Appolo", ImageUrl = "" },
                new Hospitals { Id = 2, Name = "test2", Description = "ortho", Address = "United", ImageUrl = "" },
                new Hospitals { Id = 3, Name = "test3", Description = "surgeon", Address = "Narayana", ImageUrl = "" });

            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 1, DepartmentName = "noooo", ImageUrl = ""},
                new Departments { Id = 2, DepartmentName = "Bones and Joints", ImageUrl = "" },
                new Departments { Id = 3, DepartmentName = "Women's Health", ImageUrl = "" },
                new Departments { Id = 4, DepartmentName = "General physician" , ImageUrl = "" }
                );
            modelBuilder.Entity<Patients>().HasData(
                new Patients { Id = 1, Name = "xyz", Problem = "Throat", Age = 21, BloodGroup = "O+", PhoneNumber = "9876567657", City = "Nyc", Record="" },
                new Patients { Id = 2, Name = "xyz1", Problem = "skin", Age = 22, BloodGroup = "ab+", PhoneNumber = "9876567657", City = "Del", Record = "" },
                new Patients { Id = 3, Name = "xyz2", Problem = "hair", Age = 23, BloodGroup = "b+", PhoneNumber = "9876567657", City = "Blr", Record = "" },
                new Patients { Id = 4, Name = "xyz3", Problem = "joint", Age = 24, BloodGroup = "a+", PhoneNumber = "9876567657", City = "Hyd", Record = "" }
                );
            //modelBuilder.Entity<Doctor>()
            //    .HasOne(d=>d.Department)
            //    .WithMany(de=>de.Doctors)
            //    .HasForeignKey(d=>d.DepartmentId)
            //    .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}

