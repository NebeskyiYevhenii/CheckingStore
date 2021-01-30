using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class LocationBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SMLocId { get; set; }
        public string ShelfLocId { get; set; }

        public ICollection<InspectionBL> Inspections { get; set; }
    }
}
