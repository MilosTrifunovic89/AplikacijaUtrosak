using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class SpecificationEdgeTape
    {
        public int EdgeTapeID { get; set; }
        public EdgeTape EdgeTape { get; set; }

        public int SpecificationID { get; set; }
        public Specification Specification { get; set; }

        public int Quantity { get; set; }
    }
}
