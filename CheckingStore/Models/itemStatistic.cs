using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckingStore.Models
{
    public class itemStatistic
    {
        public string ItemName { get; set; }
        public int CountVerifiedArt { get; set; }
        public int CountNoVerifiedArt { get; set; }
    }
}