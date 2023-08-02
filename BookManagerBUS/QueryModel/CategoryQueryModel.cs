using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.QueryModel
{
    public class CategoryQueryModel:PaginationRequest
    {
        public string Name { get; set; }
    }
}
