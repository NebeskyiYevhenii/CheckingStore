using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ResultInspection
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }


        public int Inspection_TypeInspectionId { get; set; }
        public Inspection_TypeInspection Inspection_TypeInspection { get; set; }
    }
}
