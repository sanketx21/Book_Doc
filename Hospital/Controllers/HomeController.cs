using Hospital.Models;
using Hospital.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Search(string searchString)
        //{
        //    var docinfo = db.Docinfo.Where(d => d.Name.Contains(searchString));
        //    var departments = db.Departments.Where(d => d.Name.Contains(searchString));
        //    var hospitals = db.Hospitals.Where(h => h.Name.Contains(searchString));

        //    var viewModel = new SearchViewModel // Assuming you have a SearchViewModel
        //    {
        //        Doctors = doctors.ToList(),
        //        Departments = departments.ToList(),
        //        Hospitals = hospitals.ToList()
        //    };

        //    return View(viewModel);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
