﻿using System.Collections.Generic;

namespace DAL.Models
{
    public class TypeInspectionBL
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Inspection_TypeInspectionBL> Inspection_TypeInspections { get; set; }

    }
}
