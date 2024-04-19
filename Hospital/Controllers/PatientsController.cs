using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hospital.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PatientsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Patients> objPatientList = _unitOfWork.patient.GetAll().ToList();
            return View(objPatientList);
        }

        public IActionResult add()
        {
                return View();
           
            
        }

        [HttpPost]


        public IActionResult Add(Patients patients, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);// gives the random name for our file
                string patientPath = Path.Combine(wwwRootPath, @"static\Images\Record");

                using (var fileStream = new FileStream(Path.Combine(patientPath, filename), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                
                patients.Record = @"\static\Images\Record\" + filename;
            }
            _unitOfWork.patient.Add(patients);
            _unitOfWork.Save();
            TempData["Success"] = "Patient added successfully";//TempData is used to give notification about the event stored in key value pair
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Patients departmentFromDb = _unitOfWork.patient.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Patients obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.patient.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Update successful";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Patients patientFromDb = _unitOfWork.patient.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (patientFromDb == null)
            {
                return NotFound();
            }
            return View(patientFromDb);
        }

        [HttpPost, ActionName("Delete")]
        //if we delete using only id then post Delete method name shud be different from get Delete method
        //we can give different name and direct it to the same method using [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)//can get the whole doctor or we can just pass id
        {
            Patients? obj = _unitOfWork.patient.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.patient.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
