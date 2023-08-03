using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerEntities.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
