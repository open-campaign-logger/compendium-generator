// <copyright file="CompendiumDbContext.cs" company="Jochen Linnemann - IT-Service">
// Copyright (c) 2017-2021 Jochen Linnemann, Cory Gill.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace Campaign.Compendium.Core.Db
{
    using CampaignKit.Compendium.Core.Models.Monsters;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database context for the Compendium Generator application.
    /// </summary>
    public class CompendiumDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the collection of Monsters in the context.
        /// </summary>
        public DbSet<Monster> Monsters { get; set; }

        /// <summary>
        /// Configures the context for use with a SQL Server database.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CompendiumDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        /// <summary>
        /// Further configures the model that was discovered by convention from the entity types exposed in DbSet properties on your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
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