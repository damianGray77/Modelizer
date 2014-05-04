using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Domains;
using System.Data.Entity;

namespace BusinessLogic.Database {
	public class DataContext : DbContext {
		public DataContext() : base(DataConnection.GetConnection(), true) { }

		public DbSet<Address> Addresses { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder ModelBuilder) {
			base.OnModelCreating(ModelBuilder);

			ModelBuilder.Entity<Address>().ToTable("Addresses");
		}
	}
}
