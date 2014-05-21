using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts.Migrations;
using Domain;
using Domain.Enums;

namespace Contexts
{
    public class LetsPlayDartsContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LetsPlayDartsContext, Configuration>());
            modelBuilder.Entity<Game>().
              HasMany(c => c.Accounts).
              WithMany(p => p.Games).
              Map(
               m =>
               {
                   m.MapLeftKey("Game_Id");
                   m.MapRightKey("Account_Id");
                   m.ToTable("AccountGames");
               });
        }
    }
}
