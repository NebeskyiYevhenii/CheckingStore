using BL.Models;
using System;

namespace BL.Models
{
    public class Inspection_TypeInspectionBL
    {
        public int Id { get; set; }

        public bool IsValid { get; set; }
        public double Remains { get; set; }
        public double ShowLevel { get; set; }
        public double Price { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime RemainsDate { get; set; }
        public int InspectionId { get; set; }
        public InspectionBL Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspectionBL TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        //public ResultInspectionBL ResultInspection { get; set; }
    }
}
