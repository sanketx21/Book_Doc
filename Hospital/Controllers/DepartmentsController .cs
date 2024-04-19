using Hospital.HospitalData.Data;
using Hospital.Models;
using Hospital.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Hospital.Controllers
{
    public class DepartmentsController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DepartmentsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Departments> objDepartmentList = _unitOfWork.Department.GetAll().ToList();
            return View(objDepartmentList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Departments departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);
                return View(departmentFromDb);
            }
        }

        [HttpPost]

        public IActionResult Upsert(Departments obj, IFormFile? file )
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string departmentPath = Path.Combine(wwwRootPath, @"static\Images");

                using (var fileStream = new FileStream(Path.Combine(departmentPath, fileName), FileMode.Create));
                {
                    file.CopyTo(fileStream);
                }
            }
            _unitOfWork.Department.Add(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Departments added successfully";//TempData is used to give notification about the event stored in key value pair
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Departments departmentFromDb = _unitOfWork. Department.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Departments obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(obj);
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
            Departments departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);//one way of retreiving works with only the primary key
            //Doctor? doctorFromDb1 = _db.Docinfo.FirstOrDefault(u=>u.Id==Id);//can be used to get the data by name or anything in the table
            //Doctor doctorFromDb2 = _db.Docinfo.Where(u=>u.Id==Id).FirstOrDefault();
            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        //if we delete using only id then post Delete method name shud be different from get Delete method
        //we can give different name and direct it to the same method using [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)//can get the whole doctor or we can just pass id
        {
            Departments obj = _unitOfWork.Department.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
