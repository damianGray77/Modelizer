using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Repositories;

namespace Modelizer.Projections {
	public abstract class ViewModel<T> : ProjectionModel<T> where T : ViewModel<T> {

	}
}
