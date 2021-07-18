using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class SpecificationMaterialConfiguration : EntityTypeConfiguration<SpecificationMaterial>
    {
        public SpecificationMaterialConfiguration()
        {
            HasKey(sm => new { sm.MaterialID, sm.SpecificationID });

            HasRequired(sm => sm.Material)
                .WithMany(m => m.SpecificationMaterials)
                .HasForeignKey(sm => sm.MaterialID)
                .WillCascadeOnDelete(false);

            HasRequired(sm => sm.Specification)
                .WithMany(s => s.SpecificationMaterials)
                .HasForeignKey(sm => sm.SpecificationID)
                .WillCascadeOnDelete(false);

            Property(sm => sm.Quantity)
                .IsRequired();
        }
    }
}
