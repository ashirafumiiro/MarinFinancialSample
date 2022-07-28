using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Repos;

namespace MarinFinancialSample.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepo genreRepo;

        public GenresController(IGenreRepo context)
        {
            genreRepo = context;
        }

        // GET: Genres
        public IActionResult Index()
        {
            return View(genreRepo.GetAll()); 
        }

        // GET: Genres/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre =  genreRepo.GetOne(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            try
            {
                genreRepo.Add(genre);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(genre);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = genreRepo.GetOne(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    genreRepo.Update(genre);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                    return View(genreRepo);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var genre = genreRepo.GetOne(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var genre = genreRepo.GetOne(id);
                if (genre != null)
                {
                    genreRepo.Delete(genre);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
