using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Modelizer.Projections {
	public abstract class ListModel<T> : ProjectionModel<T> where T : ListModel<T> {
		public abstract PropCollection<T> PropertyProjections { get; }

		public void FixSorts(IListPropertyReplacer Replacer) {
			PropCollection<T>.Enumerator e = PropertyProjections.GetEnumerator();
			while (e.MoveNext()) {
				string oldProperty = ExpressionHelper.GetMemberName(e.Current.Key);

				IEnumerable<string> newProperties = e.Current.Value.Select(o => ExpressionHelper.GetMemberName(o));
				foreach (string newProperty in newProperties) {
					Replacer.ReplaceSort(oldProperty, newProperty);
					Replacer.ReplaceGroup(oldProperty, newProperty);
				}
			}
		}
	}
}
