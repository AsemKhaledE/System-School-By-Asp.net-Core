using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDapper.Models;
using SchoolDapper.Repositoies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentCourseController(IStudentCourseRepository studentCourseRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this._studentCourseRepository = studentCourseRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }
        // GET: StudentCourseController
        public ActionResult Index()
        {
            var model = new StudentCourse
            {
                students = _studentRepository.List().ToList(),
                courses = _courseRepository.List().ToList()
            };
            return View(model);
        }

        // POST: StudentCourseController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StudentCourse studentCourse)
        {
            try
            {
                _studentCourseRepository.Add(studentCourse);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
           
        
    }
}
