using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class FittingsConfiguration : EntityTypeConfiguration<Fitting>
    {
        public FittingsConfiguration()
        {
            HasKey(f => f.FittingsId);

            Property(f => f.FittingName)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.UnitMeasure)
                .IsRequired()
                .HasMaxLength(10);

            Property(f => f.FittingName)
                .IsRequired();
        }
    }
}
