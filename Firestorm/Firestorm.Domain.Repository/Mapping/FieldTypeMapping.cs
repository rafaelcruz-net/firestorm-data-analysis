using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firestorm.Domain.Definition;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Firestorm.Infra.Data.Interfaces;

namespace Firestorm.Domain.Repository.Mapping
{
    public class FieldTypeMapping : EntityTypeConfiguration<FieldType>, IMapping
    {
        public FieldTypeMapping()
        {
            this.ToTable("__FieldType");

            this.HasKey(x => x.FieldTypeId);
            this.Property(x => x.FieldTypeId).HasColumnName("FieldTypeId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.NamedType).HasColumnName("NamedType").IsRequired();
        }

    }
}
