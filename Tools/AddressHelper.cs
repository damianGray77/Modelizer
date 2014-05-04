using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools {
	public class AddressHelper {
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }

		public AddressHelper() { }

		public AddressHelper(string Address1, string Address2, string Address3, string City, string State, string Zip) {
			this.Address1 = Address1;
			this.Address2 = Address2;
			this.Address3 = Address3;
			this.City = City;
			this.State = State;
			this.Zip = Zip;
		}

		public string FormattedAddress(string Separator) {
			string a = Address1
				.Suffix(Address2, ' ')
				.Suffix(Address3, ' ')
				.Suffix(State
					.Suffix(Zip, ' ')
					.Prefix(City, ", ")
				, Separator)
			;

			return a;
		}
	}
}
