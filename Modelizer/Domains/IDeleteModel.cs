using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Domains {
	public interface IDeleteModel {
		bool IsDeleted { get; set; }
	}
}
