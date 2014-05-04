using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Projections {
	public interface IListPropertyReplacer {
		void ReplaceSort(string OldProperty, string NewProperty);
		void ReplaceGroup(string OldProperty, string NewProperty);
	}
}
