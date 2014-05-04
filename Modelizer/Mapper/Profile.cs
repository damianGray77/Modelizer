using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Modelizer.Domains;
using Modelizer.Projections;


namespace Modelizer.Mapper {
	public abstract class Profile<TSource, TDest>
		where TSource : DomainModel<TSource>
		where TDest : ProjectionModel<TDest>
	{
		public delegate TDest Map(TSource Model);

		public abstract Expression<Map> Projection { get; }
	}
}
