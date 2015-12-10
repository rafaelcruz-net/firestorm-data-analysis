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
    public class CidadeMapping : EntityTypeConfiguration<Cidade>, IMapping
    {
        public CidadeMapping()
        {
            this.ToTable("Cidade");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("CidadeId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Nome).HasColumnName("Nome").IsRequired();

            this.HasRequired(x => x.Estado).WithOptional().Map(x =>
            {
                x.MapKey("EstadoId");
            });
        }

    }
}
