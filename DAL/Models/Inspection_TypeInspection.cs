using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Inspection_TypeInspection
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public double Remains { get; set; }
        public double ShowLevel { get; set; }
        public double Price { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime RemainsDate { get; set; }

        public int InspectionId { get; set; }
        public Inspection Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspection TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        public ResultInspection ResultInspection { get; set; }
    }
}
