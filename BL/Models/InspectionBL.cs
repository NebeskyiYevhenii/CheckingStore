﻿using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class InspectionBL
    {
        public int Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Article { get; set; }
        public DateTime CreatDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int LocationId { get; set; }
        public LocationBL Location { get; set; }


        //public int ShelfFillingId { get; set; }
        //public ShelfFillingBL ShelfFilling { get; set; }

        public ICollection<Inspection_TypeInspectionBL> Inspection_TypeInspections { get; set; }
        //public ICollection<ShelfFillingBL> ShelfFillings { get; set; }
    }
}
