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
    public class TableMapping : EntityTypeConfiguration<Table>, IMapping
    {
        public TableMapping()
        {
            this.ToTable("__Table");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasColumnName("TableId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.TableName).HasColumnName("Name").IsRequired();
            this.Property(x => x.TableSchema).HasColumnName("Schema").IsOptional();
            this.Property(x => x.Caption).HasColumnName("Caption").IsOptional();
            this.Property(x => x.Description).HasColumnName("Description").IsOptional();
            this.Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(x => x.Visible).HasColumnName("Visible").IsOptional();
            
            this.HasMany(x => x.Fields).WithRequired();
        }


        
    }
}
