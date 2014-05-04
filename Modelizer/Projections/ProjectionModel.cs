using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Projections {
	public abstract class ProjectionModel<T> : Model<T> where T : ProjectionModel<T> {
	
	}
}
