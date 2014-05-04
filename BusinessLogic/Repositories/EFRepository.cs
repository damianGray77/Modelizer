using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Database;
using Modelizer.Repositories;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Modelizer.Domains;
using System.Data;
using Modelizer;

namespace BusinessLogic.Repositories {
	public class EFRepository : Repository {
		private DbManager DbManager { get; set; }

		public EFRepository(DbManager DbManager) {
			this.DbManager = DbManager;
			CurrentUser = DbManager.CurrentUser;
		}

		protected override IQueryable<T> GetBaseQuery<T>() {
			DbSet<T> set = DbManager.Context.Set<T>();

			IQueryable<T> query = (
				from o in set
				select o
			);

			return query;
		}

		public override int RollBack() {
			return DbManager.RollBack();
		}

		public override int Commit() {
			return DbManager.Commit();
		}

		public override IEnumerable<T> Query<T>(SqlQuery SqlQuery) {
			Type t = typeof(T);
			
			bool trackable = false;

			while (typeof(Model<T>) != t) { 
				if(t.IsGenericType) {
					Type gt = t.GetGenericTypeDefinition();

					if (typeof(DomainModel<>) == gt || typeof(TrackableDomainModel<>) == gt) {
						trackable = true;
						break;
					}
				}

				t = t.BaseType;
			}

			// allows for tracking
			if (trackable) {
				DataContext c = DbManager.Context;

				return null != SqlQuery.ParamArray
					? c.Set<T>().SqlQuery(SqlQuery.Sql, SqlQuery.ParamArray)
					: c.Set<T>().SqlQuery(SqlQuery.Sql)
				;
			} else {
				System.Data.Entity.Database d = DbManager.Context.Database;

				if (ConnectionState.Open != d.Connection.State) {
					d.Connection.Open();
				}

				return null != SqlQuery.ParamArray
					? d.SqlQuery<T>(SqlQuery.Sql, SqlQuery.ParamArray)
					: d.SqlQuery<T>(SqlQuery.Sql)
				;
			}
		}

		public override Task<IEnumerable<T>> QueryAsync<T>(SqlQuery SqlQuery) {
			throw new NotImplementedException();
		}

		public override int NonQuery(SqlQuery SqlQuery) {
			return DbManager.Context.Database.ExecuteSqlCommand(SqlQuery.Sql, SqlQuery.ParamArray);
		}

		public override Task<int> NonQueryAsync(SqlQuery SqlQuery) {
			return DbManager.Context.Database.ExecuteSqlCommandAsync(SqlQuery.Sql, SqlQuery.ParamArray);
		}
	}
}
