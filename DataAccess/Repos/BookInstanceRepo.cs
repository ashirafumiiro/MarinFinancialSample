using DataAccess.Data;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class BookInstanceRepo : BaseRepo<BookInstance>, IBookInstanceRepo
    {
        public BookInstanceRepo(LibraryDbContext context) : base(context)
        {
        }
    }
}
