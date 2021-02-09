using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ResultInspectionModel
    {
        //[Key]
        //[ForeignKey("Inspection_TypeInspection")]
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }

        public int Inspection_TypeInspections_Id { get; set; }
        public Inspection_TypeInspectionModel Inspection_TypeInspection { get; set; }

        public ResultInspectionModel(int _inspection_TypeInspectionsId, bool _isValid)
        {
            IsValid = _isValid;
            Inspection_TypeInspections_Id = _inspection_TypeInspectionsId;
            CreatDate = DateTime.Now;
        }
    }
}
