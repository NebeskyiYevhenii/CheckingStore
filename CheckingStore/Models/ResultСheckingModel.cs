using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckingStore.Models
{
    public class ResultСheckingModel
    {
        public int id { get; set; }
        public DateTime CheckDate { get; set; }
        public bool CheckExpiryDate { get; set; }
        public bool CheckPrice { get; set; }
        public bool CheckCount { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int CheckJobId { get; set; }
        public CheckJobModel CheckJobModels { get; set; }
    }
}