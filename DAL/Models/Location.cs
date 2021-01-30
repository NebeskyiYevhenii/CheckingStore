using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SMLocId { get; set; }
        public string ShelfLocId { get; set; }

        public ICollection<Inspection> Inspections { get; set; }
        public ICollection<ShelfFilling> ShelfFillings { get; set; }

    }
}
