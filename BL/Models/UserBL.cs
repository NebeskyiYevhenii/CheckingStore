﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserBL
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public virtual ICollection<CheckJobBL> CheckJobsModel { get; set; }

    }
}