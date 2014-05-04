using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Database {
	public class DataConnection {
		public static SqlConnection GetConnection() {
			SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Data"].ConnectionString);

			return c;
		}
	}
}
