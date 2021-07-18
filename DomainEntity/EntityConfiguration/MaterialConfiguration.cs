using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.EntityConfiguration
{
    public class MaterialConfiguration : EntityTypeConfiguration<Material>
    {
        public MaterialConfiguration()
        {
            HasKey(l => l.MaterialId);

            Property(m => m.MaterialName)
                .IsRequired()
                .HasMaxLength(200);

            Property(l => l.Length)
                .IsRequired();

            Property(l => l.Width)
                .IsRequired();

            Property(l => l.Thickness)
                .IsRequired();

            Property(l => l.PanelType)
                .IsRequired();

            Property(l => l.Texture)
                .IsRequired();
        }
    }
}
