using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.QueryModel
{
    public class PaginationRequest
    {

        public virtual string Sort { get; set; }


        [Range(1, int.MaxValue)]
        public int? CurrentPage { get; set; } = 1;


        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } 


        public string Filter { get; set; } 


    }
}
