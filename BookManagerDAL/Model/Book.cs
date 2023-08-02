using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerDAL.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }=true;
        public  Guid AuthorId { get; set; }   
        public  Guid CategoryId { get; set; }
    }
}
