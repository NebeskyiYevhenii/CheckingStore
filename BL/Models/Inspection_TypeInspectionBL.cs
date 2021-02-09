using BL.Models;

namespace DAL.Models
{
    public class Inspection_TypeInspectionBL
    {
        public int Id { get; set; }


        public int InspectionId { get; set; }
        public InspectionBL Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspectionBL TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        //public ResultInspectionBL ResultInspection { get; set; }
    }
}
