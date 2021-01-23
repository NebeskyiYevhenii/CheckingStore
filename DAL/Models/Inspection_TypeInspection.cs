using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Inspection_TypeInspection
    {
        public int Id { get; set; }


        public int InspectionId { get; set; }
        public Inspection Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspection TypesInspection { get; set; }

        public ResultInspection ResultInspection { get; set; }
    }
}
