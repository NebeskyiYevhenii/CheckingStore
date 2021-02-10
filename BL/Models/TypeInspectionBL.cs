using System.Collections.Generic;

namespace BL.Models
{
    public class TypeInspectionBL
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Inspection_TypeInspectionBL> Inspection_TypeInspections { get; set; }

    }
}
