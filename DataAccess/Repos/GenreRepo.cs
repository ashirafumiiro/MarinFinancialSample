using DataAccess.Data;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class GenreRepo : BaseRepo<Genre>, IGenreRepo
    {
        public GenreRepo(LibraryDbContext context) : base(context)
        {
        }
    }
}
