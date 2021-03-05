using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class SmPrice_MSBL
    {
        public int Id { get; set; }
        public int StoreLoc { get; set; }
        public string Article { get; set; }
        public double Price { get; set; }
        public double ShowLevel { get; set; }
        public string ShortName { get; set; }
        public double Remains { get; set; }
        public DateTime RemainsDate { get; set; }


        //public SmPrice_MSBL(int _StoreLoc, string _Article, double _Price, float _ShowLevel, string _ShortName)
        //{
        //    StoreLoc = _StoreLoc;
        //    Article = _Article;
        //    Price = _Price;
        //    ShowLevel = _ShowLevel;
        //    ShortName = _ShortName;
        //}
    }
}
