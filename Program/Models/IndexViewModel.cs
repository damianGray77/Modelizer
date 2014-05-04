using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Repositories;
using Program.Handler;

namespace Program.Models {
	public class IndexViewModel : IBindableModel {
		public IEnumerable<AddressListModel> AddressList { get; set; }

		public static IndexViewModel Load(Repository Repository) {
			IndexViewModel m = new IndexViewModel();

			return m;
		}

		public void DataBindModel(Repository Repository) {
			AddressList = AddressListModel.Query(Repository, AddressListSqlQuery);
		}

		public SqlQuery AddressListSqlQuery {
			get {
				return new SqlQuery(@"
					SELECT *
					FROM (
						SELECT Id, Address1, Address2, Address3, City, State, ZipCode AS Zip
						FROM Addresses
						WHERE
							IsDeleted = 0
					) AS AddressListModels
				");
			}
		}
	}
}
