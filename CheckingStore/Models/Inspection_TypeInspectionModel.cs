using System;

namespace CheckingStore.Models
{
    public class Inspection_TypeInspectionModel
    {
        public int Id { get; set; }

        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }

        public int InspectionId { get; set; }
        public InspectionModel Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspectionModel TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        //public ResultInspectionModel ResultInspection { get; set; }
    }
}
