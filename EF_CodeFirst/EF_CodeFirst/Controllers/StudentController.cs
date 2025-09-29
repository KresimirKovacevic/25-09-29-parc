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
            var gradeCounts = new List<int>();
            for (int i = 0; i < students.Count; i++)
            {
                gradeCounts.Add(_context.Grades.Where( g => g.StudentId == students[i].StudentId).ToList().Count);
            }
            ViewBag.GradeCounts = gradeCounts;
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            ViewBag.CurrentGradeCount = _context.Grades.Where( g => g.StudentId == student.StudentId).ToList().Count;
            return View(student);
        }
    }
}
