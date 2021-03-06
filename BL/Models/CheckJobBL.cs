﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CheckJobBL
    {
        public int id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Store { get; set; }
        public string Article { get; set; }
        public bool CheckExpiryDate { get; set; }
        public bool CheckPrice { get; set; }
        public bool CheckCount { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime UpdateDate { get; set; }


        public virtual ICollection<ResultСheckingBL> ResultСheckings { get; set; }
    }
}
