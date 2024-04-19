using Hospital.Models;
using Hospital.HospitalData.Data;
using Hospital.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hospital.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Hospitals> objHospitalsList = _unitOfWork.Hospital.GetAll().ToList();
            //IEnumerable<SelectListItem> DepartmentList = UnitOfWork.GetAll().Select(u=> new SelectListItem 
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()
            //});
                                                                              
            return View(objHospitalsList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Hospitals obj)
        {
            _unitOfWork.Hospital.Add(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Hospital added successfully";//TempData is used to give notification about the event stored in key value pair
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Hospitals hospitalFromDb = _unitOfWork.Hospital.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (hospitalFromDb == null)
            {
                return NotFound();
            }
            return View(hospitalFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Hospitals obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Hospital.Update(obj);
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
            Hospitals hospitalFromDb = _unitOfWork.Hospital.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (hospitalFromDb == null)
            {
                return NotFound();
            }
            return View(hospitalFromDb);
        }

        [HttpPost, ActionName("Delete")]
        //if we delete using only id then post Delete method name shud be different from get Delete method
        //we can give different name and direct it to the same method using [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)//can get the whole doctor or we can just pass id
        {
            Hospitals? obj = _unitOfWork.Hospital.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Hospital.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
