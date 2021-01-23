using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ResultInspection
    {
        [Key]
        [ForeignKey("Inspection_TypeInspection")]
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatDate { get; set; }

        public Inspection_TypeInspection Inspection_TypeInspection { get; set; }
    }
}
