using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Controllers {
	public class ActionResult {
		public ActionResult(object Model = null) {
			this.Model = Model;
		}

		public object Model { get; set; }
	}
}
