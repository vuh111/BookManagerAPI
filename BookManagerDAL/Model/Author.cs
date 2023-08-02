using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerDAL.Model
{
    public class Author
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Brithday { get; set; }
        public string National { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}
