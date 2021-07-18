using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Specification
    {
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }

        public virtual ICollection<SpecificationMaterial> SpecificationMaterials { get; set; }

        public virtual ICollection<SpecificationFitting> SpecificationFittings { get; set; }

        public virtual ICollection<SpecificationEdgeTape> SpecificationEdgeTapes { get; set; }
    }
}
