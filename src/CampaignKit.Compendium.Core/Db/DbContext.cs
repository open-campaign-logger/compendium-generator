using Microsoft.EntityFrameworkCore;

using Campaign.Compendium.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Compendium.Core.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MonsterDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonsterAction>()
                .HasOne(c => c.Monster)
                .WithMany(p => p.Actions)
                .HasForeignKey(p => p.MonsterId);

            modelBuilder.Entity<MonsterReaction>()
                .HasOne(c => c.Monster)
                .WithMany(p => p.Reactions)
                .HasForeignKey(p => p.MonsterId);

            modelBuilder.Entity<MonsterSpecialAbility>()
                .HasOne(c => c.Monster)
                .WithMany(p => p.SpecialAbilities)
                .HasForeignKey(p => p.MonsterId);

            modelBuilder.Entity<MonsterLegendaryAction>()
                .HasOne(c => c.Monster)
                .WithMany(p => p.LegendaryActions)
                .HasForeignKey(p => p.MonsterId);
        }

    }
}
