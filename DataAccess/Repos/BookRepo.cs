using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(LibraryDbContext context) : base(context)
        {
        }
        public new Book GetOne(int? id)
        {
            return Context.Books.Where(x => x.Id == id.Value)
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .FirstOrDefault();
        }
        public new List<Book> GetAll()
        {
            return Context.Books.Include(x => x.Genre).Include(x => x.Author).ToList();
        }
    }
}
