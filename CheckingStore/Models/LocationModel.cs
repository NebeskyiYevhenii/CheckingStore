using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckingStore.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SMLocId { get; set; }
        public string ShelfLocId { get; set; }

        public ICollection<InspectionModel> Inspections { get; set; }
    }
}