using System;

namespace DAL.Models
{
    public class ResultInspectionBL
    {
        //[Key]
        //[ForeignKey("Inspection_TypeInspection")]
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }

        public Inspection_TypeInspectionBL Inspection_TypeInspection { get; set; }
    }
}
