using System;
using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
    public class ResultInspectionBL
    {
        [Key]
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }

        public int Inspection_TypeInspections_Id { get; set; }
        public Inspection_TypeInspectionBL Inspection_TypeInspection { get; set; }
    }
}
