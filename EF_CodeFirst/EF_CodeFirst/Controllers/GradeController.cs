using EF_CodeFirst.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_CodeFirst.Controllers
{
    public class GradeController : Controller
    {
        private readonly StudentContext _context;

        public GradeController(StudentContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var grades = _context.Grades.ToList();
            return View(grades);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var grade = _context.Grades.Find(id);
            return View(grade);
        }
    }
}