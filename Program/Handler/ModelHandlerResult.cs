using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Handler {
	public class ModelHandlerResult {
		public bool Success {  get; set; }
		public string Message { get; set; }
		public Exception Exception { get; set; }

		public ModelHandlerResult() {
			Success = true;
		}

		public void SetError(string Message, Exception Exception = null) {
			Success = false;

			this.Exception = Exception;
			this.Message = Message;
		}

		public void SetError(Exception Exception) {
			Success = false;

			this.Exception = Exception;
		}
	}
}
