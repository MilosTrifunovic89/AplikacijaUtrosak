using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class EdgeTape
    {
        public int EdgeTapeId { get; set; }
        public string EdgeTapeName { get; set; }
        public int Width { get; set; }
        public double Thickness { get; set; }
        public EdgeTapeType EdgeTapeType { get; set; }
        public int CurrentState { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<SpecificationEdgeTape> SpecificationEdgeTapes { get; set; }
    }
}
