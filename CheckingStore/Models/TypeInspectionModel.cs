using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingStore.Models
{
    public class TypeInspectionModel
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Inspection_TypeInspectionModel> Inspection_TypeInspections { get; set; }

    }
}
