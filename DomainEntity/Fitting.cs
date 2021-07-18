using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Fitting
    {
        public int FittingsId { get; set; }
        public string FittingName { get; set; }
        public string UnitMeasure { get; set; }
        public float CurrentState { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<SpecificationFitting> SpecificationFittings { get; set; }
    }
}
