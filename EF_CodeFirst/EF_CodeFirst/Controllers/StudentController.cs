using EF_CodeFirst.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_CodeFirst.Controllers
{
    public class StudentController(StudentContext context) : Controller
    {
        private readonly StudentContext _context = context;

        // GET: StudentController
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
    }
}
