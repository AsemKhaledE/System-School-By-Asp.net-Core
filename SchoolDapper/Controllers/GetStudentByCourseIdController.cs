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
    public class GetStudentByCourseIdController : Controller
    {
        private readonly IGetStudentIdByCourseIdRepository _getStudentIdByCourseIdRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public GetStudentByCourseIdController(IGetStudentIdByCourseIdRepository getStudentIdByCourseIdRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _getStudentIdByCourseIdRepository = getStudentIdByCourseIdRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        // GET: GetStudentByCourseId
        public ActionResult Index()
        {
            var model = new StudentCourse
            {
                courses = _courseRepository.List().ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetStudentById(int id)
        {
            var getListStudent = _getStudentIdByCourseIdRepository.GetListStudentById(id).ToList();
            return PartialView("GetStudentById", getListStudent);
        }

        // GET: GetStudentByCourseId/Details/5

        [HttpPost]
        public ActionResult Delete(StudentCourse studentCourse)
        {
            try
            {
                _getStudentIdByCourseIdRepository.Delete(studentCourse);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
