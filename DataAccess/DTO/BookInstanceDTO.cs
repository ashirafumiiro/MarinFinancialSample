using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class BookInstanceDTO
    {
        public int? Id { get; set; }
        public int? BookId { get; set; }
        public string Inprint { get; set; }
        public int? BookInstanceStatusId { get; set; }
        public DateTime? DueBack { get; set; }


    }
}
