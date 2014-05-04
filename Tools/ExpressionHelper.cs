using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tools {
	public class ExpressionHelper {
		public static string GetMemberName(Expression Expression) {
			MemberExpression expr = (Expression is UnaryExpression
				? (Expression as UnaryExpression).Operand
				: Expression
			) as MemberExpression;

			return null == expr ? null : expr.Member.Name;
		}
	}
}
