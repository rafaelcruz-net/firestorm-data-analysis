using Firestorm.Domain.Definition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository.Mapping
{
    public class FieldMapping : EntityTypeConfiguration<Field>
    {
        public FieldMapping()
        {
            this.ToTable("__Field");
            this.HasKey(x => x.FieldId);

            this.Property(x => x.FieldId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.FieldName).HasColumnName("__Name__").IsRequired();
            this.Property(x => x.FieldPosition).HasColumnName("__Position__").IsRequired();
            this.Property(x => x.Caption).HasColumnName("__Caption__").IsOptional();
            this.Property(x => x.Description).HasColumnName("__Description__").IsOptional();
            this.Property(x => x.Required).HasColumnName("__Required__").IsRequired();
            this.Property(x => x.IsUnique).HasColumnName("__IsUnique__").IsRequired();
            this.Property(x => x.PrimaryKey).HasColumnName("__IsPrimaryKey__").IsRequired();
            this.Property(x => x.IsIdentity).HasColumnName("__IsIdentity__").IsRequired();
            this.Property(x => x.DisplayFormat).HasColumnName("__DisplayFormat__").IsOptional();
            this.Property(x => x.Multiline).HasColumnName("__Multiline__").IsOptional();
            this.Property(x => x.Visibility).HasColumnName("__Visibility__").IsRequired();
            this.Property(x => x.HasAutoComplete).HasColumnName("__HasAutoComplete__").IsRequired();
            this.Property(x => x.AutoCompleteFieldReference).HasColumnName("__AutoCompleteFieldReference__").IsOptional();

            this.HasOptional(x => x.AutoCompleteTableReference).WithOptionalPrincipal();
            this.HasRequired(x => x.Type).WithRequiredPrincipal();
        }

    }
}

