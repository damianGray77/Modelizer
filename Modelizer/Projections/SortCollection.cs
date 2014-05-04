using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modelizer.Projections {
	public delegate object Prop<T>(T o) where T : ListModel<T>;
	public class PropList<T> : List<Expression<Prop<T>>> where T : ListModel<T> { }

	public class PropCollection<T> : Dictionary<Expression<Prop<T>>, PropList<T>> where T : ListModel<T> {
		public new PropCollection<T> AddProp(Expression<Prop<T>> Key, PropList<T> ValueList) {
			if (this.ContainsKey(Key)) {
				this[Key].AddRange(ValueList);
			} else {
				Add(Key, ValueList);
			}

			return this;
		}

		public PropCollection<T> AddProp(Expression<Prop<T>> Key, Expression<Prop<T>> Value) {
			return AddProp(Key, new PropList<T> { Value });
		}

		public PropCollection<T> AddProp(KeyValuePair<Expression<Prop<T>>, PropList<T>> KeyVal) {
			return AddProp(KeyVal.Key, KeyVal.Value);
		}

		public PropCollection<T> AddProp(KeyValuePair<Expression<Prop<T>>, Expression<Prop<T>>> KeyVal) {
			return AddProp(KeyVal.Key, new PropList<T> { KeyVal.Value });
		}
	}
}
