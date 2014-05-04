using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;

using Modelizer;
using Modelizer.Repositories;
using BusinessLogic.Dapper;
using BusinessLogic.Database;

namespace BusinessLogic.Repositories {
	public class DapperRepository : Repository {
		private DbConnection DbConnection { get; set; }

		public DapperRepository() : base() {
			DbConnection = DataConnection.GetConnection();
		}

		private void OpenConnection() {
			if (ConnectionState.Open != DbConnection.State) {
				DbConnection.Open();
			}

			if (ConnectionState.Open != DbConnection.State) {
				throw new Exception("Could not open Database connection");
			}
		}

		private void CloseConnection() {
			if (ConnectionState.Closed != DbConnection.State) {
				DbConnection.Close();
			}

			if (ConnectionState.Closed != DbConnection.State) {
				throw new Exception("Could not close Database connection");
			}
		}

		public override IEnumerable<T> Query<T>(SqlQuery SqlQuery) {
			OpenConnection();

			return SqlMapper.Query<T>(DbConnection, SqlQuery.Sql, SqlQuery.Parameters);
		}

		public override Task<IEnumerable<T>> QueryAsync<T>(SqlQuery SqlQuery) {
			OpenConnection();

			return SqlMapper.QueryAsync<T>(DbConnection, SqlQuery.Sql, SqlQuery.Parameters);
		}

		public override int NonQuery(SqlQuery SqlQuery) {
			OpenConnection();

			return SqlMapper.Execute(DbConnection, SqlQuery.Sql, SqlQuery.Parameters);
		}

		public override Task<int> NonQueryAsync(SqlQuery SqlQuery) {
			throw new NotImplementedException();
		}

		protected override IQueryable<T> GetBaseQuery<T>() {
			throw new NotImplementedException();
		}

		public override int Commit() {
			throw new NotImplementedException();
		}

		public override int RollBack() {
			throw new NotImplementedException();
		}
	}
}
