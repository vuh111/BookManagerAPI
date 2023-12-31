﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerEntities.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
