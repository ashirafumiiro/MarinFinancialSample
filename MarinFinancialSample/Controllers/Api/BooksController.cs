using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repos;
using DataAccess.Entities;

namespace MarinFinancialSample.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
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

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return new JsonResult(bookRepo.GetAll());
                //.Select(x => new{
                //    x.Id, x.Isbn,x.Summary,x.Title, Genre=x.Genre.Name, Author=$"{x.Author.FirstName} {x.Author.LastName}"
                //    }))
                ;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = bookRepo.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return new JsonResult(book);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookRepo.Update(book);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            try
            {
                bookRepo.Add(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

                return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            try
            {
                var book = bookRepo.GetOne(id);
                if (book != null)
                {
                    bookRepo.Delete(book);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
