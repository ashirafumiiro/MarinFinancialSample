using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; } = 0;

        public Author Author { get; set; }
        public Genre Genre { get; set; }

    }
}

