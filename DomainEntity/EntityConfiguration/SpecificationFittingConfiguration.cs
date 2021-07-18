using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    class SpecificationFittingConfiguration : EntityTypeConfiguration<SpecificationFitting>
    {
        public SpecificationFittingConfiguration()
        {
            HasKey(sf => new { sf.FittingID, sf.SpecificationID });

            HasRequired(sf => sf.Fitting)
                .WithMany(f => f.SpecificationFittings)
                .HasForeignKey(sf => sf.FittingID)
                .WillCascadeOnDelete(false);

            HasRequired(sf => sf.Specification)
                .WithMany(s => s.SpecificationFittings)
                .HasForeignKey(sf => sf.SpecificationID)
                .WillCascadeOnDelete(false);

            Property(sf => sf.Quantity)
                .IsRequired();
        }
    }
}
