// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using Addresses.StreetAddressLines.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Addresses.StreetAddresses.DatabaseContext
{
    /// <summary>EntityFrameworkCore database context for StreetAddress entities</summary>
    public class StreetAddressDbContext : StreetAddressLineDbContext
    {
        /// <summary>Constructs StreetAddressDbContext EntityFrameworkCore database context using given options</summary>
        public StreetAddressDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>Contains set of StreetAddress entities</summary>
        public DbSet<StreetAddress> StreetAddresses { get; set; }

        /// <summary>Configures EntityFramework database creation - adds unique index to model</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StreetAddress>().HasIndex(new StreetAddress().GetUniqueIndex()).IsUnique();
        }
    }
}
