﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckingStore.Models
{
    public class InspectionModel
    {
        public int Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Article { get; set; }
        public DateTime CreatDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int LocationId { get; set; }
        public LocationModel Location { get; set; }

        //public int ShelfFillingId { get; set; }
        //public ShelfFillingModel ShelfFilling { get; set; }

        public ICollection<Inspection_TypeInspectionModel> Inspection_TypeInspections { get; set; }
        //public ICollection<ShelfFillingModel> ShelfFillings { get; set; }
    }
}