using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Domains;

namespace BusinessLogic.Domains {
	public class Address : TrackableDomainModel<Address> {
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }

		protected Address() { }

		public Address(string Address1) {
			this.Address1 = Address1;
		}

		public Address(string Address1, string City, string State, string ZipCode) {
			this.Address1 = Address1;
			this.City = City;
			this.State = State;
			this.ZipCode = ZipCode;
		}

		public Address(string Address1, string Address2, string Address3, string City, string State, string ZipCode) {
			this.Address1 = Address1;
			this.Address2 = Address2;
			this.Address3 = Address3;
			this.City = City;
			this.State = State;
			this.ZipCode = ZipCode;
		}
	}
}
