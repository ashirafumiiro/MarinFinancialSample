using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BookInstance : EntityBase
    {
        public int BookId { get; set; }
        public string Inprint { get; set; }
        public int BookInstanceStatusId { get; set; }
        public DateTime? DueBack { get; set; }

        public Book Book { get; set; }
        public BookInstanceStatus Status { get; set; }


    }
}
