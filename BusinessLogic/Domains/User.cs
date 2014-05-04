using Modelizer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domains {
	public class User : TrackableDomainModel<User>, IUser, IActiveModel {
		public string Username { get; set; }
		public string Password { get; set; }

		public bool IsActive { get; set; }

		protected User() { }

		public User(string Username, string Password) {
			this.Username = Username;
			this.Password = Password;
		}
	}
}
