using DataAccess.Repos;
using MarinFinancialSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarinFinancialSample.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        private readonly IGenreRepo genreRepo;
        private readonly IAuthorRepo authorRepo;
        public HomeController(IBookRepo bookRepo, IGenreRepo genreRepo, IAuthorRepo authorRepo)
        {
            this.bookRepo = bookRepo;
            this.genreRepo = genreRepo;
            this.authorRepo = authorRepo;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = new EntityCountViewModel()
            {
                BookCount = bookRepo.GetAll().Count(),
                GenreCount = genreRepo.GetAll().Count(),
                AuthorCount = authorRepo.GetAll().Count(),
            };
            return new JsonResult(model);
        }
    }
}
