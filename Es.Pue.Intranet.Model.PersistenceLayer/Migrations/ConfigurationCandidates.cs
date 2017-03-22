namespace Es.Pue.Intranet.Model.PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationCandidates : DbMigrationsConfiguration<Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts.CandidatesDBContext>
    {
        public ConfigurationCandidates()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts.CandidatesDBContext context)
        {
            
        }
    }
}
