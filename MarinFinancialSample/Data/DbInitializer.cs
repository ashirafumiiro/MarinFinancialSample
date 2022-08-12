using DataAccess.Data;
using DataAccess.Entities;
using System.Diagnostics;

namespace MarinFinancialSample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        {
            // Look for any students.
            if (context.Authors.Any())
            {
                return;   // DB has been seeded
            }

            var authors = new Author[]
            {
                new Author{FirstName="Bova",LastName="Ben",DateOfBirth=DateTime.Parse("1935-11-01")},
                new Author{FirstName="Billings",LastName="Bob",DateOfBirth=DateTime.Parse("1945-09-01")},
                new Author{FirstName="Rothfuss",LastName="Patric",DateOfBirth=DateTime.Parse("1973-06-06")},

            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre{Name = "Fantasy"},
                new Genre{Name = "French Poetry"},
                new Genre{Name = "Science Fiction"}
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();



            var books = new Book[]
            {
                new Book{Title="Apes and Anges", Summary="Humankind headed out to the stars not for conquest, nor exploration, nor even for curiosity.",
                Isbn="9780765379528", AuthorId=1,GenreId=3},
                new Book{Title="Death Wave", Summary="In Ben Bova's previous novel New Earth, Jordan Kell led the first human mission beyond the solar system.",
                Isbn="9780765379504", GenreId=3, AuthorId=1},
                new Book{Title="The Name of the Wind (The Kingkiller Chronicle, #1)", AuthorId=3, GenreId=1, Isbn="9781473211896", Summary="I have stolen princesses back from sleeping barrow kings."}
                
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            var statuses = new BookInstanceStatus[]
{
                new BookInstanceStatus{Name="Maintenance"},
                new BookInstanceStatus{Name="Available"},
                new BookInstanceStatus{Name="Loaned"}
            };

            context.BookInstanceStatuses.AddRange(statuses);
            context.SaveChanges();

            var bookInstances = new BookInstance[]
            {
                new BookInstance{BookId=1,BookInstanceStatusId=1,Inprint="Gollancz, 2015", DueBack=DateTime.Parse("2022-07-12")},
                new BookInstance{BookId=1,BookInstanceStatusId=2,Inprint="LLC, 2015", DueBack=DateTime.Parse("2022-08-07")},
                new BookInstance{BookId=2,BookInstanceStatusId=3,Inprint="LLC, 2015", DueBack=DateTime.Parse("2022-07-12")},
            };

            context.BookInstances.AddRange(bookInstances);
            context.SaveChanges();
        }
    }
}
