using CheckingStore.Models;

namespace CheckingStore.Models
{
    public class Inspection_TypeInspectionModel
    {
        public int Id { get; set; }


        public int InspectionId { get; set; }
        public InspectionModel Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspectionModel TypesInspection { get; set; }

        //public int ResultInspectionId { get; set; }
        //public ResultInspectionModel ResultInspection { get; set; }
    }
}
