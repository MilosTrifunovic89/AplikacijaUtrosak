using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class SpecificationMaterial
    {
        public int SpecificationID { get; set; }
        public Specification Specification { get; set; }

        public int MaterialID { get; set; }
        public Material Material { get; set; }

        public double Quantity { get; set; }
    }
}
