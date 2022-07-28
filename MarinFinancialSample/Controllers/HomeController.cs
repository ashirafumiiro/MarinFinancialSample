using MarinFinancialSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Repos;

namespace MarinFinancialSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepo bookRepo;
        private readonly IBookInstanceRepo bookInstanceRepo;
        private readonly IGenreRepo genreRepo;
        private readonly IAuthorRepo authorRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepo bookRepo, IBookInstanceRepo bookInstanceRepo, IGenreRepo genreRepo, IAuthorRepo authorRepo)
        {
            _logger = logger;
            this.bookRepo = bookRepo;
            this.bookInstanceRepo = bookInstanceRepo;
            this.genreRepo = genreRepo;
            this.authorRepo = authorRepo;
        }

        public IActionResult Index()
        {
            var model = new EntityCountViewModel()
            {
                BookCount = bookRepo.GetAll().Count(),
                GenreCount = genreRepo.GetAll().Count(),
                AuthorCount = authorRepo.GetAll().Count(),
                BookInstanceCount = bookInstanceRepo.GetAll().Count(),
                CopiesAvailable = bookInstanceRepo.GetSome(p => p.BookInstanceStatusId == (int)DataAccess.Enums.BookInstanceStatus.Available).Count()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}