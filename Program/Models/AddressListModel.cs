using Modelizer.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Program.Models {
	public class AddressListModel : ListModel<AddressListModel> {
		public int Id { get; set; }
		private string Address1 { get; set; }
		private string Address2 { get; set; }
		private string Address3 { get; set; }
		private string City { get; set; }
		private string State { get; set; }
		private string Zip { get; set; }

		public string Address {
			get {
				AddressHelper a = new AddressHelper(Address1, Address2, Address3, City, State, Zip);

				return a.FormattedAddress("\n");
			}
		}

		public override PropCollection<AddressListModel> PropertyProjections {
			get {
				return new PropCollection<AddressListModel>()
					.AddProp(o => o.Address, new PropList<AddressListModel> {
						o => o.Address1
						, o => o.Address2
						, o => o.Address3
						, o => o.City
						, o => o.State
						, o => o.Zip
					})
				;
			}
		}
	}
}
