namespace Firestorm.Domain.Repository.Migrations
{
    using Firestorm.Domain.Definition;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Firestorm.Domain.Repository.Context.FirestormContext>
    {

        IDbSet<FieldType> FieldType
        {
            get;
            set;
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Firestorm.Domain.Repository.Context.FirestormContext context)
        {

            this.FieldType = context.Set<FieldType>();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
