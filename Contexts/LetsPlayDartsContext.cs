﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts.Migrations;
using Domain;

namespace Contexts
{
    public class LetsPlayDartsContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LetsPlayDartsContext, Configuration>());
        }
    }
}
