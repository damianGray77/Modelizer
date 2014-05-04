using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Repositories;

using BusinessLogic.Database;
using BusinessLogic.Repositories;
using BusinessLogic.Domains;
using Program.Handler;

namespace Program.Controllers {
	public class Controller {
		protected DbManager dbMan;
		protected Repository repo;

		public Repository Repository {
			get { return repo; }
			private set { repo = value; }
		}

		public DbManager DbManager {
			get { return dbMan; }
			private set { dbMan = value; }
		}

		public Controller() {
			dbMan = new DbManager();
			repo = new EFRepository(DbManager);

			User u = User.GetById(repo, 1);

			dbMan.CurrentUser = u;
		}

		public ActionResult View(object Model) {
			return new ActionResult(Model);
		}

		public ActionResult View(IBindableModel Model) {
			Model.DataBindModel(Repository);

			return new ActionResult(Model);
		}
	}
}
