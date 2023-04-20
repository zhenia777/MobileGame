using Microsoft.EntityFrameworkCore;
using MobileGame.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGame.Domain
{
    internal class ApplicationContext : DbContext
    {
        private string databasePath;
        public DbSet<GameResult> GameResults { get; set; }
        public ApplicationContext(string databasePath)
        {
            this.databasePath = databasePath;

            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={databasePath}");
        }
    }
}
