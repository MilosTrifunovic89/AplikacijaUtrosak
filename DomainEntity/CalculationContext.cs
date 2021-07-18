using DomainEntity.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class CalculationContext : DbContext
    {
        public CalculationContext()
        {

        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<EdgeTape> EdgeTapes { get; set; }
        public DbSet<Fitting> Fittings { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SpecificationMaterial> SpecificationMaterials { get; set; }
        public DbSet<SpecificationFitting> SpecificationFittings { get; set; }
        public DbSet<SpecificationEdgeTape> SpecificationEdgeTapes { get; set; }
        public DbSet<Operater> Operaters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new EdgeTapeConfiguration());
            modelBuilder.Configurations.Add(new FittingsConfiguration());
            modelBuilder.Configurations.Add(new SpecificationConfiguration());
            modelBuilder.Configurations.Add(new SpecificationMaterialConfiguration());
            modelBuilder.Configurations.Add(new SpecificationFittingConfiguration());
            modelBuilder.Configurations.Add(new SpecificationEdgeTapeConfiguration());
            modelBuilder.Configurations.Add(new OperaterConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
