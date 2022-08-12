using DataAccess.Entities;
using DataAccess.Repos;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject
{
    public class BookTest
    {
        [Fact]
        public void GetBooks_Returnes_Repo_Books()
        {
            var mockRepo = new Mock<IBookRepo>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetTestBooks());

            var controller = new MarinFinancialSample.Controllers.Api.BooksController(mockRepo.Object, null, null);

            var booksResponse = controller.GetBooks();

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(booksResponse);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(jsonResult.Value);
            Assert.Equal(3, model.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetOne_ReturnsAJsonResult_WithABookIfIdExists(int id)
        {
            //Arange
            var mockRepo = new Mock<IBookRepo>();
            mockRepo.Setup(repo => repo.GetOne(id))
               .Returns(GetTestBooks().Where(p => p.Id == id).FirstOrDefault());

            var controller = new MarinFinancialSample.Controllers.Api.BooksController(mockRepo.Object, null, null);

            // Act
            var result =  controller.GetBook(id);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var model = Assert.IsAssignableFrom<Book>(jsonResult.Value);
            Assert.NotNull(model);

        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public async void GetOne_Returns404_IfIdDoesNotExists(int id)
        {
            //Arange
            var mockRepo = new Mock<IBookRepo>();
            mockRepo.Setup(repo => repo.GetOne(id))
               .Returns(GetTestBooks().Where(p => p.Id == id).FirstOrDefault());

            var controller = new MarinFinancialSample.Controllers.Api.BooksController(mockRepo.Object, null, null);

            // Act
            var result = controller.GetBook(id);

            //Assert
            var jsonResult = Assert.IsType<NotFoundResult>(result);

        }

        public List<Book> GetTestBooks()
        {
            var books = new Book[]
            {
                new Book{Id = 1,Title="Apes and Anges", Summary="Humankind headed out to the stars not for conquest, nor exploration, nor even for curiosity.",
                Isbn="9780765379528", AuthorId=1,GenreId=3},
                new Book{Id=2, Title="Death Wave", Summary="In Ben Bova's previous novel New Earth, Jordan Kell led the first human mission beyond the solar system.",
                Isbn="9780765379504", GenreId=3, AuthorId=1},
                new Book{Id=3, Title="The Name of the Wind (The Kingkiller Chronicle, #1)", AuthorId=3, GenreId=1, Isbn="9781473211896", Summary="I have stolen princesses back from sleeping barrow kings."}

            };
            return books.ToList();
        }

    }
}