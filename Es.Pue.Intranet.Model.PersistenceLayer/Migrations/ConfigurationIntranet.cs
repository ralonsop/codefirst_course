namespace Es.Pue.Intranet.Model.PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationIntranet : DbMigrationsConfiguration<Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts.IntranetDBContext>
    {
        public ConfigurationIntranet()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts.IntranetDBContext context)
        {
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
