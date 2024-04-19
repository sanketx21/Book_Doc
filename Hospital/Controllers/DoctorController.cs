using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Doctor> objDoctorsList = _unitOfWork.Doctor.GetAll().ToList();
            
            return View(objDoctorsList);
        }

        public IActionResult Add()
        {
            //IEnumerable<SelectListItem> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().ToList().Select(u => new SelectListItem
            //{
            //    Text = u.DepartmentName,
            //    Value = u.Id.ToString()
            //});

            //ViewBag.Departmentslist = DepartmentList;
           
            return View();
        }

        [HttpPost]

        public IActionResult Add(Doctor obj)
        {
            _unitOfWork.Doctor.Add(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Doctor added successfully";//TempData is used to give notification about the event stored in key value pair
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doctor doctorFromDb = _unitOfWork.Doctor.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Doctor obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Doctor.Update(obj);
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
            Doctor doctorFromDb = _unitOfWork.Doctor.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        [HttpPost, ActionName("Delete")]
        //if we delete using only id then post Delete method name shud be different from get Delete method
        //we can give different name and direct it to the same method using [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)//can get the whole doctor or we can just pass id
        {
            Doctor? obj = _unitOfWork.Doctor.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Doctor.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
