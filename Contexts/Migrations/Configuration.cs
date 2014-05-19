using Domain;

namespace Contexts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LetsPlayDartsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "LetsPlayDartsContext";
        }

        protected override void Seed(LetsPlayDartsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.GameTypes.AddOrUpdate(
              g => g.Name,
              new GameType { Name = "Tac tics" },
              new GameType { Name = "501" },
              new GameType { Name = "Twenty and below" },
              new GameType { Name = "301" }
            );
            
        }
    }
}
