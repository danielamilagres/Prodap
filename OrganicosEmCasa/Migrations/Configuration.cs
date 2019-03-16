namespace OrganicosEmCasa.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrganicosEmCasa.Models.OrganicosEmCasaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OrganicosEmCasa.Models.OrganicosEmCasaDBContext";
        }

        protected override void Seed(OrganicosEmCasa.Models.OrganicosEmCasaDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
