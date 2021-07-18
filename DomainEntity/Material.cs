using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Thickness { get; set; }
        public double PanelSurface { get; set; }
        public double CurrentPanelSurface { get; set; }
        public int CurrentNumberOfPanel { get; set; }
        public PanelType PanelType { get; set; }
        public decimal Price { get; set; }
        public bool Texture { get; set; }

        public virtual ICollection<SpecificationMaterial> SpecificationMaterials { get; set; }
    }
}
