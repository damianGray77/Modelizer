using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Program.Handler;
using Program.Controllers;

namespace Program.Handler {
	public static class UpdatableModelExtension {
		public static ModelHandlerResult Handle(this IUpdatableModel Model, Controller Controller) {
			ModelHandlerResult r = new ModelHandlerResult();

			try {
				Model.Update(Controller.Repository);
			} catch(Exception ex) {
				r.SetError(ex);
			}

			return r;
		}
	}
}
