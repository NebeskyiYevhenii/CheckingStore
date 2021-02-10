using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class SMPriceBL
    {
        public string STORELOC { get; set; }
        public string ARTICLE { get; set; }
        public string PRICE { get; set; }
        public string SHOWLEVEL { get; set; }
        public string SHORTNAME { get; set; }

        public SMPriceBL(string _STORELOC, string _ARTICLE, string _PRICE, string _SHOWLEVEL, string _SHORTNAME)
        {
            STORELOC = _STORELOC;
            ARTICLE = _ARTICLE;
            PRICE = _PRICE;
            SHOWLEVEL = _SHOWLEVEL;
            SHORTNAME = _SHORTNAME;
        }
    }
}
