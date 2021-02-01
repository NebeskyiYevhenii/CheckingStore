﻿using CheckingStore.Models;

namespace DAL.Models
{
    public class Inspection_TypeInspectionModel
    {
        public int Id { get; set; }


        public int InspectionId { get; set; }
        public InspectionModel Inspection { get; set; }

        public int TypesInspectionId { get; set; }
        public TypeInspectionModel TypesInspection { get; set; }

        public ResultInspectionModel ResultInspection { get; set; }
    }
}
