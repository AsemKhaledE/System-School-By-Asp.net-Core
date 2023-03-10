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
    public class GetCourseByStudentIdController : Controller
    {
        private readonly IGetCourseByStudentIdRepository _getCourseByStudentIdRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public GetCourseByStudentIdController(IGetCourseByStudentIdRepository getCourseByStudentIdRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _getCourseByStudentIdRepository = getCourseByStudentIdRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }
        // GET: GetCourseByStudentIdController
        public ActionResult Index()
        {
            var model = new StudentCourse
            {
                students = _studentRepository.List().ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetstudentCourses(int id)
        {
            var getListCourses = _getCourseByStudentIdRepository.GetListCoursesById(id).ToList();
            return PartialView("GetstudentCourses", getListCourses);
        }

        [HttpPost]
        public ActionResult Delete(StudentCourse studentCourse)
        {
            try
            {
                _getCourseByStudentIdRepository.Delete(studentCourse);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

    }
}
