using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class SpecificationEdgeTapeConfiguration : EntityTypeConfiguration<SpecificationEdgeTape>
    {
        public SpecificationEdgeTapeConfiguration()
        {
            HasKey(se => new { se.EdgeTapeID, se.SpecificationID });

            HasRequired(se => se.EdgeTape)
                .WithMany(e => e.SpecificationEdgeTapes)
                .HasForeignKey(se => se.EdgeTapeID)
                .WillCascadeOnDelete(false);

            HasRequired(se => se.Specification)
                .WithMany(s => s.SpecificationEdgeTapes)
                .HasForeignKey(se => se.SpecificationID)
                .WillCascadeOnDelete(false);

            Property(se => se.Quantity)
                .IsRequired();
        }
    }
}
