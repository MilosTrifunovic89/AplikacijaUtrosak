using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class EdgeTapeConfiguration : EntityTypeConfiguration<EdgeTape>
    {
        public EdgeTapeConfiguration()
        {
            HasKey(e => e.EdgeTapeId);

            Property(e => e.EdgeTapeName)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Width)
                .IsRequired();

            Property(e => e.Thickness)
                .IsRequired();

            Property(e => e.EdgeTapeType)
                .IsRequired();

            Property(e => e.Price)
                .IsRequired();
        }
    }
}
