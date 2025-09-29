using EF_CodeFirst.Data;
using EF_CodeFirst.Models;
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
            List<Student> students = new List<Student>();
            for(int i = 0; i < grades.Count; i++)
            {
                students.Add(_context.Students.Find(grades[i].StudentId));
            }
            ViewBag.Students = students;
            return View(grades);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var grade = _context.Grades.Find(id);
            ViewBag.CurrentStudent = _context.Students.Find(grade.StudentId);
            return View(grade);
        }
    }
}