using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    class SpecificationConfiguration : EntityTypeConfiguration<Specification>
    {
        public SpecificationConfiguration()
        {
            HasKey(s => s.SpecificationId);

            Property(s => s.SpecificationName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
