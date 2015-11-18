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
    public class TableMapping : EntityTypeConfiguration<Table>
    {
        public TableMapping()
        {
            this.ToTable("__Table");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasColumnName("__TableId__").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.TableName).HasColumnName("__Name__").IsRequired();
            this.Property(x => x.TableSchema).HasColumnName("__Schema__").IsOptional();
            this.Property(x => x.Caption).HasColumnName("__Caption__").IsOptional();
            this.Property(x => x.Description).HasColumnName("__Description__").IsOptional();
            this.Property(x => x.CreationDate).HasColumnName("__CreationDate__").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            
            this.HasMany(x => x.Fields).WithRequired();
        }


        
    }
}
