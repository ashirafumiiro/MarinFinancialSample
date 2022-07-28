using DataAccess.Data;
using DataAccess.Entities;
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
    }
}
