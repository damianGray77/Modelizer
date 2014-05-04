using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Domains;
using BusinessLogic.Repositories;
using BusinessLogic.Database;

using Modelizer.Repositories;
using Modelizer.Projections;

using Program.Models;
using Program.Controllers;
using Program.Handler;

namespace Program {
	class Program {
		static void Main(string[] args) {
			TestController.Test();

			/*IEnumerable<AddressViewModel> list = Query.Get<AddressViewModel>(@"
				SELECT Id, Address1, Address2, Address3, City, State, ZipCode AS Zip
				FROM Addresses
				WHERE IsDeleted = 0
			");*/

			Console.ReadKey();
		}
	}

	public class TestController : Controller {
		public static void Test() {
			TestController c = new TestController();

			IndexViewModel im = c.TestIndexView().Model as IndexViewModel;

			AddressViewModel am = c.TestView(1).Model as AddressViewModel;

			var list = Address.Query(c.repo, new SqlQuery(@"
				SELECT *
				FROM Addresses
				WHERE IsDeleted = 0
			"));//.GroupBy(o => new { o.ZipCode, o.State });

			foreach (Address o in list) {
				Console.WriteLine(o);
			}

			foreach (AddressListModel o in im.AddressList) {
				Console.WriteLine(o);
			}

			c.TestView(am);
		}

		public ActionResult TestIndexView() {
			IndexViewModel m = IndexViewModel.Load(repo);

			return View(m);
		}

		public ActionResult TestView(int Id) {
			AddressViewModel m = AddressViewModel.Load(repo, Id);

			return View(m);
		}

		public ActionResult TestView(AddressViewModel Model) {
			ModelHandlerResult r = Model.Handle(this);

			return View(Model);
		}
	}
}
