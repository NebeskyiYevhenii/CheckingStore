﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Inspection
   {
        public int Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Article { get; set; }
        public DateTime CreatDate { get; set; }

        public int Userid { get; set; }
        public User User { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public virtual ICollection<Inspection_TypeInspection> Inspection_TypeInspections { get; set; }
    }
}
