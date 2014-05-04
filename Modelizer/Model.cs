using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Repositories;
using Tools;

namespace Modelizer {
	public abstract class Model<T> where T : Model<T> {
		public static Task<IEnumerable<T>> QueryAsync(Repository Repository, SqlQuery SqlQuery) {
			if (null == Repository || null == SqlQuery || string.IsNullOrWhiteSpace(SqlQuery.Sql)) {
				return null;
			}

			return Repository.QueryAsync<T>(SqlQuery);
		}

		public static IEnumerable<T> Query(Repository Repository, SqlQuery SqlQuery) {
			if (null == Repository || null == SqlQuery || string.IsNullOrWhiteSpace(SqlQuery.Sql)) {
				return null;
			}

			return Repository.Query<T>(SqlQuery);
		}

		public override string ToString() {
				return StringHelper.AsString(this);
		}
	}
}
