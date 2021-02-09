namespace DAL.Models
{
    public class Inspection_TypeInspection
    {
        public int Id { get; set; }


        public int InspectionId { get; set; }
        public Inspection Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspection TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        public ResultInspection ResultInspection { get; set; }
    }
}
