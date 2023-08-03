using BookManagerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.ResponeModel
{
    public class BookResponeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; } = true;
        public AuthorEntity? Author { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
