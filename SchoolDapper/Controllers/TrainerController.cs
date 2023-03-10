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
    public class TrainerController : Controller
    {
        readonly ITrainerRepository _trainerRepository;
        public TrainerController(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        // GET: TrainerController
        public ActionResult Index()
        {
            var trainer = _trainerRepository.List();
            return View(trainer);
        }

        // GET: TrainerController/Details/5
        public ActionResult Details(int id)
        {
            var trainer = _trainerRepository.Find(id);
            return View(trainer);
        }

        // GET: TrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            try
            {
                _trainerRepository.Add(trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            var trainer = _trainerRepository.Find(id);
            return View(trainer);
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainer trainer)
        {
            try
            {
                _trainerRepository.Update(trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Delete/5
        public ActionResult Delete(int id)
        {
            var trainer = _trainerRepository.Find(id);
            return View(trainer);
        }

        // POST: TrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trainer trainer)
        {
            try
            {
                _trainerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
