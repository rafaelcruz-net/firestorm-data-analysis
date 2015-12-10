namespace Firestorm.Domain.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.__Field",
                c => new
                    {
                        FieldId = c.Guid(nullable: false, identity: true),
                        TableId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Position = c.Byte(nullable: false),
                        Caption = c.String(),
                        Description = c.String(),
                        Required = c.Boolean(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        IsPrimaryKey = c.Boolean(nullable: false),
                        IsIdentity = c.Boolean(nullable: false),
                        DisplayFormat = c.String(),
                        Multiline = c.Boolean(),
                        Visibility = c.Byte(nullable: false),
                        HasAutoComplete = c.Boolean(nullable: false),
                        AutoCompleteFieldReference = c.String(),
                        Table_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FieldId)
                .ForeignKey("dbo.__Table", t => t.Table_Id, cascadeDelete: true)
                .Index(t => t.Table_Id);
            
            CreateTable(
                "dbo.__Table",
                c => new
                    {
                        TableId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Caption = c.String(),
                        Description = c.String(),
                        Visible = c.Boolean(),
                        CreationDate = c.DateTime(nullable: false),
                        Schema = c.String(),
                        Field_FieldId = c.Guid(),
                    })
                .PrimaryKey(t => t.TableId)
                .ForeignKey("dbo.__Field", t => t.Field_FieldId)
                .Index(t => t.Field_FieldId);
            
            CreateTable(
                "dbo.__FieldType",
                c => new
                    {
                        FieldTypeId = c.Guid(nullable: false, identity: true),
                        NamedType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FieldTypeId)
                .ForeignKey("dbo.__Field", t => t.FieldTypeId)
                .Index(t => t.FieldTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.__FieldType", "FieldTypeId", "dbo.__Field");
            DropForeignKey("dbo.__Table", "Field_FieldId", "dbo.__Field");
            DropForeignKey("dbo.__Field", "Table_Id", "dbo.__Table");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropIndex("dbo.__FieldType", new[] { "FieldTypeId" });
            DropIndex("dbo.__Table", new[] { "Field_FieldId" });
            DropIndex("dbo.__Field", new[] { "Table_Id" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropTable("dbo.__FieldType");
            DropTable("dbo.__Table");
            DropTable("dbo.__Field");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
        }
    }
}
