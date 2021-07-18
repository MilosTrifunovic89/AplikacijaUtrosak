using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class OperaterConfiguration : EntityTypeConfiguration<Operater>
    {
        public OperaterConfiguration()
        {
            HasKey(o => o.OperaterID);

            Property(o => o.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(o => o.LastName)
                .IsRequired()
                .HasMaxLength(70);

            Property(o => o.Password)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
