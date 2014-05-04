using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Tools;
using BusinessLogic.Domains;

using Modelizer.Mapper;
using Modelizer.Repositories;
using Modelizer.Projections;

using Program.Handler;

namespace Program.Models {
	public class AddressViewModel : ViewModel<AddressViewModel>, IBindableModel, IUpdatableModel {
		public int Id { get; set; }

		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }

		public static AddressViewModel Load(Repository Repository, int Id) {
			Address a = Address.GetById(Repository, Id);
			
			AddressViewModel m = a.Project(new AddressProfile())
				?? new AddressViewModel()
			;

			return m;
		}

		public void DataBindModel(Repository Repository) {

		}

		public void Update(Repository Repository) {
			Address a = Address.GetById(Repository, Id);

			a.Address1 = Address1;
			a.Address2 = Address2;
			a.Address3 = Address3;
			a.City = City;
			a.State = State;
			a.ZipCode = Zip;

			Repository.Update(a);
		}

		public class AddressProfile : Profile<Address, AddressViewModel> {
			public override Expression<Map> Projection {
				get {
					return o => new AddressViewModel {
						Id = o.Id
						, Address1 = o.Address1
						, Address2 = o.Address2
						, Address3 = o.Address3
						, City = o.City
						, State = o.State
						, Zip = o.ZipCode
					};
				}
			}
		}
	}
}
