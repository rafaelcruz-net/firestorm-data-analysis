using Firestorm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository.Mapping
{
    public class EstadoMapping: EntityTypeConfiguration<Estado>, IMapping
    {
        public EstadoMapping()
        {
            this.ToTable("Estado");

            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("EstadoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Nome).HasColumnName("Nome");
            this.Property(x => x.UF).HasColumnName("UF");
        }
    }
}
