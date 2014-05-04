using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Repositories {
	public class SqlQuery {
		public string Sql { get; set; }
		public object Parameters { get; set; }

		public SqlParameter[] ParamArray {
			get {
				if (null == Parameters) {
					return null;
				}

				return Parameters.GetType()
					.GetProperties()
					.Select(o => new SqlParameter(o.Name, o.GetValue(Parameters, null)))
					.ToArray()
				;
			}
		}

		public SqlQuery(string Sql, object Parameters = null) {
			this.Sql = Sql;
			this.Parameters = Parameters;
		}
	}
}
