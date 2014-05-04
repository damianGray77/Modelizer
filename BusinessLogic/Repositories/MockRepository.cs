using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Domains;

using Modelizer.Domains;
using Modelizer.Repositories;

namespace BusinessLogic.Repositories {
	/*public class MockRepository : Repository {
		private static IEnumerable<Address> AddressList = new List<Address> {
			new Address("110 Hawks Bend Lane", "Odenville", "AL", "35120") { Id = 1 }
			, new Address("5330 Technology Lane", "Tarrant", "AL", "35210") { Id = 2 }
		};

		private static IEnumerable<User> UserList = new List<User> {
			new User("damiangray", "icicle") { Id = 1, IsActive = true }
		};

		private static IDictionary<Type, IEnumerable> ListDictionary = new Dictionary<Type, IEnumerable> {
				{ typeof(Address), AddressList }
				, { typeof(User), UserList }
		};

		public override IQueryable<T> GetBaseQuery<T>() {
			Type t = typeof(T);

			return !ListDictionary.ContainsKey(t)
				? null
				: ListDictionary[t].Cast<T>().AsQueryable();
		}
	}*/
}
