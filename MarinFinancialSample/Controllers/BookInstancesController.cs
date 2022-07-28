using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Entities;

namespace MarinFinancialSample.Controllers
{
    public class BookInstancesController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookInstancesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookInstances
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _context.BookInstances.Include(b => b.Book).Include(b => b.Status);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: BookInstances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookInstances == null)
            {
                return NotFound();
            }

            var bookInstance = await _context.BookInstances
                .Include(b => b.Book)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookInstance == null)
            {
                return NotFound();
            }

            return View(bookInstance);
        }

        // GET: BookInstances/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["BookInstanceStatusId"] = new SelectList(_context.BookInstanceStatuses, "Id", "Id");
            return View();
        }

        // POST: BookInstances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Inprint,BookInstanceStatusId,DueBack,Id")] BookInstance bookInstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookInstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookInstance.BookId);
            ViewData["BookInstanceStatusId"] = new SelectList(_context.BookInstanceStatuses, "Id", "Id", bookInstance.BookInstanceStatusId);
            return View(bookInstance);
        }

        // GET: BookInstances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookInstances == null)
            {
                return NotFound();
            }

            var bookInstance = await _context.BookInstances.FindAsync(id);
            if (bookInstance == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookInstance.BookId);
            ViewData["BookInstanceStatusId"] = new SelectList(_context.BookInstanceStatuses, "Id", "Id", bookInstance.BookInstanceStatusId);
            return View(bookInstance);
        }

        // POST: BookInstances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Inprint,BookInstanceStatusId,DueBack,Id")] BookInstance bookInstance)
        {
            if (id != bookInstance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookInstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookInstanceExists(bookInstance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookInstance.BookId);
            ViewData["BookInstanceStatusId"] = new SelectList(_context.BookInstanceStatuses, "Id", "Id", bookInstance.BookInstanceStatusId);
            return View(bookInstance);
        }

        // GET: BookInstances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookInstances == null)
            {
                return NotFound();
            }

            var bookInstance = await _context.BookInstances
                .Include(b => b.Book)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookInstance == null)
            {
                return NotFound();
            }

            return View(bookInstance);
        }

        // POST: BookInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookInstances == null)
            {
                return Problem("Entity set 'LibraryDbContext.BookInstances'  is null.");
            }
            var bookInstance = await _context.BookInstances.FindAsync(id);
            if (bookInstance != null)
            {
                _context.BookInstances.Remove(bookInstance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookInstanceExists(int id)
        {
          return (_context.BookInstances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
