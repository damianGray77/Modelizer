using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Domains;
using Modelizer.Repositories;

namespace BusinessLogic.Database {
	public class DbManager {
		public IUser CurrentUser { get; set; }

		public DataContext Context { get; private set; }

		public DbManager(IUser CurrentUser = null) {
			System.Data.Entity.Database.SetInitializer<DataContext>(null);
			Context = new DataContext();

			this.CurrentUser = CurrentUser;
		}

		~DbManager() {
			if (null != Context) {
				Context.Dispose();
			}
		}

		public int Commit() {
			return Context.SaveChanges();
		}

		public int RollBack() {
			return 0;//return Context.DeleteChanges();
		}
	}
}
