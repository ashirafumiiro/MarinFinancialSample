using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repos;
using DataAccess.Entities;

namespace MarinFinancialSample.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepo bookRepo;
        private readonly IGenreRepo genreRepo;
        private readonly IAuthorRepo authorRepo;

        public BooksController(IBookRepo bookRepo, IGenreRepo genreRepo, IAuthorRepo authorRepo)
        {
            this.bookRepo = bookRepo;
            this.genreRepo = genreRepo;
            this.authorRepo = authorRepo;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(bookRepo.GetAll());
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookRepo.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(genreRepo.GetAll(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(authorRepo.GetAll(), "Id", "FullName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Summary,Isbn,AuthorId,GenreId")] Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewData["GenreId"] = new SelectList(genreRepo.GetAll(), "Id", "Name", book.GenreId);
                ViewData["AuthorId"] = new SelectList(authorRepo.GetAll(), "Id", "FullName", book.AuthorId);
                return View(book);
            }
            try
            {
                bookRepo.Add(book);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                ViewData["GenreId"] = new SelectList(genreRepo.GetAll(), "Id", "Name", book.GenreId);
                ViewData["AuthorId"] = new SelectList(authorRepo.GetAll(), "Id", "FullName", book.AuthorId);
                return View(book);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = bookRepo.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(genreRepo.GetAll(), "Id", "Name", book.GenreId);
            ViewData["AuthorId"] = new SelectList(authorRepo.GetAll(), "Id", "FullName", book.AuthorId);
            return View(book);
            
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Title,Summary,Isbn,AuthorId,GenreId,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookRepo.Update(book);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                    return View(book);
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreId"] = new SelectList(genreRepo.GetAll(), "Id", "Name", book.GenreId);
            ViewData["AuthorId"] = new SelectList(authorRepo.GetAll(), "Id", "FullName", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var book = bookRepo.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var book = bookRepo.GetOne(id);
                if (book != null)
                {
                    bookRepo.Delete(book);
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
