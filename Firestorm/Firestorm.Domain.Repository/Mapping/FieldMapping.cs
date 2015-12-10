using Firestorm.Domain.Definition;
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
    public class FieldMapping : EntityTypeConfiguration<Field>, IMapping
    {
        public FieldMapping()
        {
            this.ToTable("__Field");
            this.HasKey(x => x.FieldId);

            this.Property(x => x.FieldId).HasColumnName("FieldId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.FieldName).HasColumnName("Name").IsRequired();
            this.Property(x => x.FieldPosition).HasColumnName("Position").IsRequired();
            this.Property(x => x.Caption).HasColumnName("Caption").IsOptional();
            this.Property(x => x.Description).HasColumnName("Description").IsOptional();
            this.Property(x => x.Required).HasColumnName("Required").IsRequired();
            this.Property(x => x.IsUnique).HasColumnName("IsUnique").IsRequired();
            this.Property(x => x.PrimaryKey).HasColumnName("IsPrimaryKey").IsRequired();
            this.Property(x => x.IsIdentity).HasColumnName("IsIdentity").IsRequired();
            this.Property(x => x.DisplayFormat).HasColumnName("DisplayFormat").IsOptional();
            this.Property(x => x.Multiline).HasColumnName("Multiline").IsOptional();
            this.Property(x => x.Visibility).HasColumnName("Visibility").IsRequired();
            this.Property(x => x.HasAutoComplete).HasColumnName("HasAutoComplete").IsRequired();
            this.Property(x => x.AutoCompleteFieldReference).HasColumnName("AutoCompleteFieldReference").IsOptional();

            this.HasOptional(x => x.AutoCompleteTableReference).WithOptionalPrincipal();
            this.HasRequired(x => x.Type).WithRequiredPrincipal();
        }

    }
}

