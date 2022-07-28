using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class BookDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Isbn { get; set; }
        public int? AutherId { get; set; }
        public int? GenreId { get; set; } = 0;

    }
}

